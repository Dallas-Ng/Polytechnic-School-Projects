"""
Written by:
Dallas 180522Y
"""
from random import randint as r
from datetime import datetime, timedelta


def fare(location):
    location = location.lower()
    if location == 'yishun':
        new_fare = 10
    elif location == 'sembawang':
        new_fare = 5
    elif location == 'woodlands':
        new_fare = 2
    else:
        new_fare = 4
    return new_fare


def status_generate():
    status_list = []
    for i in range(10):
        generated = r(0, 100)
        if 70 > generated >= 0:
            generated = 'Operational'
        elif 100 >= generated >= 70:
            generated = 'Maintenance'
        append_this = ((i+1), generated)
        status_list.append(append_this)
    return status_list


# Time ============================================
def date():
    time_string = datetime.now().strftime('%d/%m/%Y %X')
    return time_string


def current_date():
    time_string = datetime.now().strftime('%d/%m/%Y')
    return time_string


def current_date_booking():
    time_string = datetime.now() - timedelta(days=1)
    return time_string.strftime('%d/%m/%Y')


def convert(string):
    time_string = '%s%s%s' % (string[-4:], string[3:5], string[0:2])
    return time_string


def current_time():
    time_string = datetime.now().strftime('%H:%M')
    return time_string


def change_time(string):
    if string[-2:] == 'PM':
        front = (int(string[:2]) + 12)
        back = (string[2:])
        string = (str(front) + back)
    return string


def padding(number):
    str(number)
    if 0 < number < 10:
        number = '0' + str(number)
        return number
    elif number == 0:
        return '00'
    else:
        return str(number)
