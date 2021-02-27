import boto3
from pprint import pprint
import time

# # replace this with  your bucket on where you like to store your query results, your workgroup and your databases name
#***** Warning: This program will throw error if you dint have the Bucket. Creat a bucket and give its path in output-location
# output_location = 's3://dharu-query-result/Gradproj/athenaoutput'
# my_workgroup = 'primary'
# mydatabase = 'dmdatabase'

def create_table(output_location,my_workgroup,mydatabase):
    print ('Creating table if not already exists. Query in query.createtbl.txt')
    query_filename = 'query_createtbl.txt'
    f = open(query_filename, 'r')
    query = f.read()
    f.close()
    print (query)
    QueryResponse = start_query(query,output_location,my_workgroup,mydatabase,query_id=None)


def start_query(query,output_location,my_workgroup,mydatabase,query_id):
    if query_id is None:
        print ('starting execution of your query')
        startresp = ath.start_query_execution(
            QueryString=query,
            QueryExecutionContext={
                'Database': mydatabase
            },
            ResultConfiguration={
                'OutputLocation': output_location
            },
            WorkGroup=my_workgroup
        )
        return startresp

def get_create_database(name):
    glue  = boto3.client('glue')
    glueresp1 = glue.get_databases()
    list = []
    for dblist in glueresp1['DatabaseList']:
        list.append(dblist['Name'])
    pprint(list)
    if name not in list:
        print('creating database', name)
        response = glue.create_database(
            DatabaseInput={
                'Name': name
            }
        )
    else:
        print('you are good')


if __name__ == "__main__":

    ath = boto3.client('athena')
    #replace this with  your bucket on where you like to store your query results, your workgroup and your databases name
    output_location = 's3://dharu-query-result/Gradproj/athenaoutput'
    # output_location = 's3://dharu-lambda-user'
    my_workgroup = 'primary'
    mydatabase = 'dmdatabase'

    #create a database if not present

    get_create_database(mydatabase)

    # Create table if it does not exist in default database. go to query_build.txt to change any parameters.
    create_table(output_location,my_workgroup,mydatabase)

    # Build your query in query_build.txt

    f = open('query_build.txt', 'r')
    query = f.read()
    f.close()
    print('query from query_build.txt:',query)
    startresp = start_query(query, output_location, my_workgroup, mydatabase, query_id=None)

    query_exec_id = startresp['QueryExecutionId']

    getresp = ath.get_query_execution(
        QueryExecutionId=query_exec_id
    )

    # pprint(getresp)

    query_state = getresp['QueryExecution']['Status']['State']

    if query_state != 'SUCCEEDED':
        if query_state in ['FAILED','CANCELLED']:
            print ('The Query is {}.'.format(query_state))
        if query_state in ['QUEUED','RUNNING']:
            print('Executing.....please wait 20 sec for your query to execute.....\n')
            time.sleep(20)

            getresp = ath.get_query_execution(
                QueryExecutionId=query_exec_id
            )
            query_state = getresp['QueryExecution']['Status']['State']
            if query_state != 'SUCCEEDED':
                print('The state of the Query is {} and queryID is {}. Try again later'.format(query_state,query_exec_id))

    if query_state == 'SUCCEEDED':
        output_file = getresp['QueryExecution']['ResultConfiguration']['OutputLocation']
        # print(output_file)

        s3 = boto3.resource('s3')
        filepath = output_file
        [bucket,infilename] = filepath[5:].split('/',1)
        obj = s3.Object(bucket, infilename)
        body = obj.get()['Body'].read().decode('utf-8')
        print(body)
    else :
        pprint(getresp)
        if query_state in ['RUNNING','QUEUED']:
            print ('Your query takes longer than 20 sec. Increase the time.sleep() few more seconds and try again!!!')
        else:
            print('Please check your query or try gain later!!!')
            print('create your own output bucket with proper permissions in s3 and paste its path in output-location!!!')
            print (getresp['QueryExecution']['Status']['StateChangeReason'])







