import csv
import sys

def read_file(filename):
    try:
        with open(filename,newline="") as readfile:
            readfile_reader = csv.reader(readfile,delimiter = "\t")
            contents = []
            for row in readfile_reader:
                contents.append(row)
            return contents[0][0]  
    except (FileNotFoundError,IndexError):
        print("File not found  or Empty Input file")
        print("Creating a new money file with balance $0.0")
        print()
        write_file(filename,'0')
        print("Success! Money file created with zero balance!")
        print()
        money = float(read_file(filename))
        return money
    except Exception as e:
        print(" Unexcepted error occured while reading file. Terminating program.")
        print(type(e),e)
        sys.exit()

def write_file(filename,text):
    try:
        if type(text) != list:
            text = [str(text)]
        with open(filename,"w",newline = "") as writefile:
            file_writer = csv.writer(writefile,delimiter = "\t")
            file_writer.writerow(text)
        #print("Write Success")
    except Exception as e:
        print(" Unexcepted error occured while writing file. Terminating program.")
        print(type(e),e)
        sys.exit()

if __name__=="__main__":
    filename = "test.txt"
    text_in = [100,100]
    write_file(filename,text_in)
    text = read_file(filename)
    if text == None:
        print("File not found")
    else:
        print(text)
