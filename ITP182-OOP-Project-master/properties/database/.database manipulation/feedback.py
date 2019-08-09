import shelve as s
from properties.external.shelving.shelving import *
from random import randint as r
from properties.external.shelving.object_feedback import *

years = ['2008', '2009', '2010', '2011', '2012', '2013', '2014', '2015', '2016', '2017', '2018', ]
months = ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December', ]
answer = ['yes', 'no']
names = ['JohnR', 'Tester', 'DanialLim', 'LoganPaul', 'HollandJor']
db = access_database('feedback', 'feedback')


"""def booking():
    string = ''
    for i in range(16):
        string += str(r(0, 9))
    return string[:10] + '.' + string[11:]


for i in range(20):
    obj = Feedback(names[r(0, 4)], booking(), answer[r(0, 1)], answer[r(0, 1)], answer[r(0, 1)], answer[r(0, 1)], answer[r(0, 1)], answer[r(0, 1)], answer[r(0, 1)], answer[r(0, 1)], )
    db[obj.get_feedback_id()] = obj


for key in db.keys():
    obj = db[key]
    obj.set_month(months[r(0, 11)])
    obj.set_year(years[r(0, 10)])
    obj.set_booking_id(booking())
    db[key] = obj
"""