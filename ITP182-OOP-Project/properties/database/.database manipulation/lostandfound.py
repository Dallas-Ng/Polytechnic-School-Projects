from properties.external.shelving.object_lostandfound import *
from properties.external.shelving.shelving import *
from random import randint as r

#     def __init__(self, username, description, item, date, status, time):

time = ['2008', '2009', '2010', '2011', '2012', '2013', '2014', '2015', '2016', '2017', '2018', ]
months = ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December', ]
answer = ['yes', 'no']
names = ['JohnR', 'Tester', 'DanialLim', 'LoganPaul', 'HollandJor']
db = access_database('feedback', 'lostandfound')
items = ['water bottle', 'jacket', 'laptop', 'phone']
colors = ['pink', 'white', 'black', 'blue']

for i in range(20):
    obj = LostAndFound(names[r(0, 4)], items[r(0, 3)], colors[r(0,3)], (str(r(1, 31)) + months[r(0, 11)]), 'Lost', '10AM')
    db[obj.get_lost_and_found_id()] = obj