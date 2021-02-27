import boto3
import uuid
from pprint import pprint
import time

s3 = boto3.resource('s3')
input_filepath = 'C:/Users/mdhar/Desktop/Dharani/Cloud_computing/gradproj/reviewtxt/LifeOfPi.txt'
outbucket = 'dharucomprebucket'
len = input_filepath.rfind('/')
if len != -1:
    filename_split = input_filepath[len+1:].split('.')
    filename = '{}_{}.{}'.format(filename_split[0],uuid.uuid4(),filename_split[-1])
else:
    filename_split = input_filepath.split('.')
    filename = '{}.{}'.format(uuid.uuid4(),filename_split[-1])
s3.meta.client.upload_file(input_filepath,outbucket, filename,ExtraArgs={'ACL':'public-read'})


# s3 = boto3.client('s3')
# response = s3.put_object(
#     Body = input_filepath,
#     Bucket = outbucket,
#     Key = filename
# )

print('wait for the lamda to process your input...')
time.sleep(7)
s3 = boto3.resource('s3')
# filepath  = 's3://dharu-database/sentimeter/supported_cd.csv'
# filepath  = 's3://dharu-database/sentimeter/valid-lang-cd.csv'
filepath = 's3://dharu-output-bucket/gradproj/output.txt'
[bucket,infilename] = filepath[5:].split('/',1)
obj = s3.Object(bucket, infilename)
body = obj.get()['Body'].read().decode('utf-8')
print(body)


