import json
import boto3

# input files used: 
# 's3://dharu-database/sentimeter/supported_cd.csv'  --> list of supported language code for sentiment analysis
# 's3://dharu-database/sentimeter/cd_lang.csv' --> list of language code and respective language
# output file: 's3://dharu-output-bucket/gradproj/output.txt' 

def get_filename(record):
    s3 = boto3.client('s3')
    bucketname = str(record['s3']['bucket']['name'])
    filename = str(record['s3']['object']['key'])
    print ('The buckname and the filename are ',bucketname, filename)
    return bucketname, filename
    
def get_filecontent(bucketname,filename):
    s3 = boto3.client('s3')
    getobj = s3.get_object(Bucket = bucketname, Key = filename)
    file_content = getobj['Body'].read().decode('utf-8')
    print ('File content extracted!!')
    return file_content
    
def get_language(text):
    client = boto3.client('comprehend')
    langresponse = client.detect_dominant_language(Text=text)
    for lang in langresponse['Languages']:
        lang_cd = lang['LanguageCode']
    print (lang_cd)
    is_supported = is_supported_lang_cd(lang_cd)
    language = get_lang_from_code(lang_cd)
    return (lang_cd, language, is_supported)
    
    
def is_supported_lang_cd(lang_cd):
    print ('I am in is_supported_lang_cd')
    # 's3://dharu-database/sentimeter/supported_cd.csv' contains ist of supported language code for analysis of the sentiment
    valid_list_tmp = read_from_s3('s3://dharu-database/sentimeter/supported_cd.csv')
    valid_list = valid_list_tmp.split()
    if lang_cd in valid_list:
        return True
    else:
        return False
        
def get_lang_from_code(lang_cd):
    print ('I am in get_lang_from_code')
    # 's3://dharu-database/sentimeter/cd_lang.csv' contains ist of all language code and language
    temp_lang_list = read_from_s3('s3://dharu-database/sentimeter/cd_lang.csv')
    lang_list = temp_lang_list.split()
    for langlist in lang_list:
        if lang_cd == langlist[0:len(lang_cd)]:
            return (langlist[len(lang_cd)+1:])
    return 'Unavailable'
    
    
def read_from_s3(s3filepath):
    # s3 filepath should contain the file name in 's3://BucketName/folder/subfolder/filename.fmt' format. 
    s3 = boto3.resource('s3')
    [bucket,key] = s3filepath[5:].split('/',1)
    obj = s3.Object(bucket, key)
    txt_body = obj.get()['Body'].read().decode('utf-8')
    return txt_body
    

    
def get_sentiment(file_content,language_cd,is_supported):
    if is_supported:
        client = boto3.client('comprehend')
        textresp = client.detect_sentiment(Text=file_content, LanguageCode= language_cd)
        print(textresp)
        sentiment = textresp['Sentiment'].capitalize()
        confidence_percent = round((textresp['SentimentScore'][sentiment])*100,2)
        print(f'Sentiment: {sentiment} Confidentscore : {confidence_percent}')
        return (sentiment, confidence_percent)
    else:
        error_message = 'This language {language_cd} is not supported for sentiment analysis'.format(language_cd = language_cd)
        print (error_message)
        return ('Lang not Supported','Unavailable')
    
def get_entity_title(file_content,language_cd,is_supported):
    if is_supported:
        entityTitle=[]
        client = boto3.client('comprehend')
        entity_response = client.detect_entities(Text=file_content, LanguageCode=language_cd)
        for entity in entity_response['Entities']:
            if entity['Type'] == 'TITLE':
                entityTitle.append(entity['Text'])
        print (entityTitle)
        #removing Duplicates in the list
        entityTitle = list(dict.fromkeys(entityTitle))
        print (entityTitle)
        # combinig all titles into a single list seperated by comma
        entityTitle = ','.join(entityTitle)
        print (entityTitle)
        if len(entityTitle) == 0:
            return 'Unavailable'
        return entityTitle
    else:
        return 'Unavailable'
        
    
    

def write_output(timestamp,filename,code,language,entity_title,sentiment,confidence_percent, outbucket,outfilename):
    print ('writing this output')
    old_content = get_filecontent(outbucket,outfilename)
    new_row = '{col1}|{col2}|{col3}|{col4}|{col5}|{col6}|{col7}'.format( col1=timestamp, \
                                                                        col2=filename,  \
                                                                        col3=code,      \
                                                                        col4=language,  \
                                                                        col5=entity_title,  \
                                                                        col6=sentiment,     \
                                                                        col7=confidence_percent)
    new_content = '{old_content}\n{new_row}'.format(old_content=old_content,new_row=new_row) 
    print (new_content)
    s3 = boto3.resource('s3')
    obj = s3.Object(outbucket,outfilename)
    obj.put(Body=new_content)
    
def error_handler(errormsg):
    print (errormsg)
    

def lambda_handler(event, context):
    
    #  An event is triggered when an object is uploaded to dharucomprebucket
    
    if event:
        print(event)
        for record in event['Records']:
            # The uploaded file name is extracted. If it is not a text file, then it the control goes to error handler function
            (bucketname, filename) = get_filename(record)
            if filename[-4:] == '.txt':
                # The Lengt of the text should be between 20 and 5000 for better results.
                file_content = get_filecontent(bucketname,filename)
                if 20 <= len(file_content) <= 5000:
                    timestamp = record['eventTime']
                    print (timestamp)
                    (language_cd, language, is_supported) = get_language(file_content)
                    [sentiment,confidence_percent] = get_sentiment(file_content,language_cd,is_supported)
                    entity_title = get_entity_title(file_content,language_cd,is_supported)
                    write_output(timestamp,filename,language_cd,language,entity_title,sentiment,confidence_percent,outbucket='dharu-output-bucket',outfilename = 'gradproj/output.txt')
                else:
                    errormsg = 'Invalid text lenght!!Try again !!!  The text should contain minimum of 20 characters and a maximum of 5000 characters.Your character lenght is {}'.format(len(file_content))
                    error_handler(errormsg)
            else:
                errormsg = 'This system only analyse .txt files. Please upload txt file and try again!'
                error_handler(errormsg)
            
                
    
   
