import boto3
from pprint import pprint
from image_helpers import get_image

def get_emotion(emotions):
    return sorted([(e['Confidence'], e['Type']) for e in emotions],reverse=True)[0][1]

client = boto3.client('rekognition')

# imgurl = 'http://www.idothat.us/images/idothat-img/features/pool-patio-lanai/ft-pool-patio-lanai-2.jpg'
# imgurl = 'http://s1.favim.com/orig/18/beach-birds-cute-nature-parrots-Favim.com-194539.jpg'
# imgurl = 'https://www.parrots.org/images/uploads/dreamstime_C_47716185.jpg'
# img = "images/portrait.jpg"
# img = "images/old.jpg"
# img = "images/red-blue.jpg"
img = 'https://thumb7.shutterstock.com/display_pic_with_logo/363082/322019009/stock-photo-diverse-people-s-faces-collage-of-diverse-multi-ethnic-and-mixed-age-people-expressing-different-322019009.jpg'

imgbytes = get_image(img)
rekresp = client.detect_faces(Image={"Bytes": imgbytes}, Attributes=['ALL'])

numfaces = len(rekresp['FaceDetails'])
print(f'Found {numfaces} ',end='')
if numfaces == 1:
    print('face')
else:
    print('faces')

for facedeets in rekresp['FaceDetails']:
    fmtstr = '{gender} age {lowage}-{highage} '

    # facial hair detection
    if facedeets['Mustache']['Value'] and facedeets['Beard']['Value']:
        fmtstr += 'with beard and mustache,'
    elif facedeets['Mustache']['Value']:
        fmtstr += 'with mustache,'
    elif facedeets['Beard']['Value']:
        fmtstr += 'with beard,'

    # sunglass/eyeglass detection
    if facedeets['Sunglasses']['Value']:
        fmtstr += 'wearing sunglasses, '
    elif facedeets['Eyeglasses']['Value']:
        fmtstr += 'wearing eyeglass, '
    # emotion
    fmtstr += 'looks {emotion}'


    print(
        fmtstr.format(
            gender = facedeets['Gender']['Value'],
            lowage = facedeets['AgeRange']['Low'],
            highage = facedeets['AgeRange']['Low'],
            emotion = get_emotion(facedeets['Emotions']).lower()
        )
    )
