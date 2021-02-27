from PIL import Image, ImageDraw, ImageFont
import boto3
from pprint import pprint, pformat
from io import BytesIO
from image_helpers import get_image

def format_text(text, columns):
    '''
    Returns a copy of text that will not span more than the specified number of columns
    :param text: the text
    :param columns: the maximum number of columns
    :return: the formatted text
    '''
    # format the text to fit the specified columns
    import re
    text = re.sub('[()\']', '', pformat(text, width=columns))
    text = re.sub('\n ', '\n', text)
    return text

def text_rect_size(text, font, draw=None):
    """
    Returns the size of the rectangle to be used to
    draw as the background for the text.
    :param text: the text to be displayed
    :param font: the font to be used
    :param draw: an ImageDraw.Draw object
    :return: the size of the rectangle to be used to draw as the background for the text
    """
    if draw is None:
        dummy_img = Image.new('RGB', (0, 0), (255, 255, 255, 0))
        draw = ImageDraw.Draw(dummy_img)
        (width, height) = draw.multiline_textsize(text, font=font)
        del draw
    else:
        (width, height) = draw.multiline_textsize(text, font=font)
    return (width * 1.1, height * 1.3)


def add_text_to_img(img, text, pos=(0, 0), color=(255, 255, 255), bgcolor=(255,0,0,255),
                    columns=60,
                    font=ImageFont.truetype('ariblk.ttf', 22)):
    '''
    Creates and returns a copy of the image with the specified text displayed on it
    :param img: the (Pillow) image
    :param text: the text to display
    :param pos: a 2 tuple containing the xpos, and ypos of the text
    :param color: the fill color of the text
    :param bgcolor: the background color of the box behind the text
    :param columns: the max number of columns for the text
    :param font: the font to use
    :return: a copy of the image with the specified text displayed on it
    '''

    # make a blank image for the text, initialized to transparent text color
    txt_img = Image.new('RGBA', img.size, (255, 255, 255, 0))
    draw = ImageDraw.Draw(txt_img)
    # format the text
    text = format_text(text, columns)
    # get the size of the text drawn in the specified font
    (text_width, text_height) = ImageDraw.Draw(img).multiline_textsize(text, font=font)

    # compute positions and box size
    (xpos, ypos) = pos
    rwidth = text_width * 1.1
    rheight = text_height * 1.4
    text_xpos = xpos + (rwidth - text_width) / 2
    text_ypos = ypos + (rheight - text_height) / 2

    # draw the rectangle (slightly larger) than the text
    draw.rectangle([xpos, ypos, xpos + rwidth, ypos + rheight], fill=bgcolor)

    # draw the text on top of the rectangle
    draw.multiline_text((text_xpos, text_ypos), text, font=font, fill=color)

    del draw # clean up the ImageDraw object
    return Image.alpha_composite(img.convert('RGBA'), txt_img)



client = boto3.client('rekognition')

#img = 'https://render.fineartamerica.com/images/rendered/default/poster/8/10/break/images/artworkimages/medium/1/pizza-slice-diane-diederich.jpg'
#img = 'https://comicvine1.cbsistatic.com/uploads/original/11121/111212274/4690993-8981038732-dq-si.png'
#img = 'https://placepull.com/wp-content/uploads/2019/05/Boston-Pizza-table-and-chairs-1200x675.png'
#img = 'https://truffle-assets.imgix.net/671e1dd0-strawberry-dream-birthday-cake_pc.jpg'
#img = 'https://images-na.ssl-images-amazon.com/images/I/71HI72z65BL._AC_SL1500_.jpg'
#img = 'https://s3-media0.fl.yelpcdn.com/bphoto/QRiaZGP9l2VpbpR2MYpYUg/348s.jpg'
#img = 'https://thecomeback.com/wp-content/uploads/2016/03/PizzaHut_donuts.jpg'
#img = 'https://cdn3.vectorstock.com/i/1000x1000/33/32/top-view-dinner-table-with-european-dishes-and-vector-20923332.jpg'
#img = 'https://images.fineartamerica.com/images/artworkimages/mediumlarge/1/2-laser-eyes-space-cat-riding-rainbow-pizza-random-galaxy.jpg'
#img = 'https://s3.amazonaws.com/pizza-delight-cdn/upload/menu/PD18_WEB_KidsMeal_kittycat_pizza_Website-1920x10804.png'
img = 'https://peterblacksbooks.files.wordpress.com/2013/12/1330381536_pictures-of-people-eating-pizza_23.jpg'
imgbytes = get_image(img)
rekresp = client.detect_labels(Image={"Bytes": imgbytes})
img = Image.open(BytesIO(imgbytes))
#pprint(rekresp['Labels'])
is_pizza = False
is_food = False
for label in rekresp['Labels']:
    if label['Name'] == 'Pizza':
        is_pizza = True
    if label['Name'] == 'Food':
        is_food = True
if is_pizza:
    text = 'Pizza'
    bgcolor1 = (0, 255, 0, 255)
    print(text)
else:
    if not is_food:
        text = 'Not Food'
    else:
        text = 'Not Pizza'
    bgcolor1 = (255, 0, 0, 255)
    print(text)
font=ImageFont.truetype('ariblk.ttf', 40)
(rect_width,rect_height) = text_rect_size(text, font, draw=None)
print(rect_width,rect_height)
print(img.size)

xpos = (img.size[0]/2) - (rect_width/2)
imgnew = add_text_to_img(img, text,bgcolor = bgcolor1,pos=(xpos,0),font=ImageFont.truetype('ariblk.ttf', 50))

imgnew.show()

