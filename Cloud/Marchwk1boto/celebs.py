import boto3
from pprint import pprint
from image_helpers import get_image

client = boto3.client('rekognition')

#imgurl = 'https://media1.popsugar-assets.com/files/thumbor/xptPz9chB_kMwxzqI9qMCZrK_YA/fit-in/1024x1024/filters:format_auto-!!-:strip_icc-!!-/2015/07/13/766/n/1922398/3d3a7ee5_11698501_923697884352975_2728822964439153485_n.jpg'
# imgurl = 'http://media.comicbook.com/uploads1/2015/07/fox-comic-con-panel-144933.jpg'
# imgurl = 'https://i.pinimg.com/736x/09/6d/50/096d50a67612c4f607c6769cb7ef9372--breaking-bad-art-celebrity-selfies.jpg'
#imgurl = 'https://media1.popsugar-assets.com/files/thumbor/MwkLetqNFa8kgNiMLHbCD0_gU6o/fit-in/2048xorig/filters:format_auto-!!-:strip_icc-!!-/2017/05/26/828/n/1922398/4acfca0159287980c7e2c5.58293727_edit_img_image_43579626_1495818800/i/Hugh-Jackman-Deborra-Lee-Furness-Pictures.jpg'
#imgurl = 'http://del.h-cdn.co/assets/17/10/980x490/landscape-1489072977-delish-wolverine-hugh-jackman.jpg'
#imgurl = 'https://www.biography.com/.image/t_share/MTE1ODA0OTcxOTA3NTgxNDUz/hugh-jackman-16599916-1-402.jpg'
#imgurl = 'https://www.famousbirthdays.com/headshots/hugh-jackman-4.jpg'
imgurl = 'C:/Users/mdhar/Desktop/Dharani/Cloud_computing/Pics/trumps.png'

imgbytes = get_image(imgurl)
rekresp = client.recognize_celebrities(Image={'Bytes': imgbytes})

for face in rekresp['CelebrityFaces']:
    print(f'Name : {face["Name"]}, confidance : {face["MatchConfidence"]}, Url : {face["Urls"]}')