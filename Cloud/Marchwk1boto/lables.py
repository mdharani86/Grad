import boto3
from pprint import pprint
from image_helpers import get_image

client = boto3.client('rekognition')

imgurl = 'http://www.idothat.us/images/idothat-img/features/pool-patio-lanai/ft-pool-patio-lanai-2.jpg'
#imgurl = 'http://s1.favim.com/orig/18/beach-birds-cute-nature-parrots-Favim.com-194539.jpg'
#imgurl = 'https://www.parrots.org/images/uploads/dreamstime_C_47716185.jpg'

imgbytes = get_image(imgurl)
#print(type(imgbytes))

rekresp = client.detect_labels(Image = {'Bytes': imgbytes})
pprint(rekresp)