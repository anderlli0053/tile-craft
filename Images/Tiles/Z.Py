
# import required module
import os
# assign directory
directory = './'
 
# iterate over files in
# that directory
for filename in os.listdir(directory):
    f = os.path.join(directory, filename)
    n = os.path.join(directory, ''.join(word.title()
                     for word in filename.split('_')))
    # checking if it is a file
    if os.path.isfile(f):
        os.rename(f, n)