from PIL import Image, ImageDraw
import boto3
from pprint import pprint
from io import BytesIO
from image_helpers import get_image

def bbox_to_coords(bbox, image_width, Image_height):
    upper_left_x = bbox['Left'] * image_width
    upper_y = bbox['Top'] * img_height
    bottom_right_x =  upper_left_x + (bbox['Width'] * image_width)
    bottom_y = upper_y + (bbox['Height'] * img_height)
    return [upper_left_x, upper_y, bottom_right_x, bottom_y]

client = boto3.client('rekognition')

img = 'https://thumb7.shutterstock.com/display_pic_with_logo/363082/322019009/stock-photo-diverse-people-s-faces-collage-of-diverse-multi-ethnic-and-mixed-age-people-expressing-different-322019009.jpg'
imgbytes = get_image(img)

img = Image.open(BytesIO(imgbytes))

(img_width, img_height) = img.size
rekresp = client.detect_faces(Image={'Bytes': imgbytes},
                              Attributes = ['ALL'])
draw = ImageDraw.Draw(img)

for facedeets in rekresp['FaceDetails']:
    bbox = facedeets['BoundingBox']
    draw.rectangle(bbox_to_coords(bbox, img_width, img_height),
                   outline=(0,200,0))
del draw
img.show()


