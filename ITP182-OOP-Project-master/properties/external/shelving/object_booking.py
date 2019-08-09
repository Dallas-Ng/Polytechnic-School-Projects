"""
Written by:
Dallas 180522Y
"""
from properties.external.shelving.inherit import *
from properties.external.library_python.functions import *
from properties.external.library_python.form import *
import datetime


class Booking(InheritThis):
    def __init__(self, username, name, location, school, date, time, fare):
        super().__init__(username)

        booking_id = str(datetime.datetime.now().timestamp())
        self.__booking_id = booking_id
        creation_date = datetime.datetime.now().strftime('%Y-%m-%d %X')
        self.__creation_date = creation_date

        self.__deleted_by = ''
        self.__completed = 'Not completed'

        self.__name = name
        self.__location = location
        self.__school = school
        self.__date = date
        self.__time = time
        self.__fare = fare

    # ACCESSOR ================================================================
    def get_booking_id(self):
        return self.__booking_id

    def get_creation_date(self):
        return self.__creation_date

    def get_deleted_by(self):
        return self.__deleted_by

    def get_completed_status(self):
        return self.__completed

    ####
    def get_name(self):
        return self.__name

    def get_location(self):
        return self.__location

    def get_school(self):
        return self.__school

    def get_date(self):
        return self.__date

    def get_time(self):
        return self.__time

    def get_fare(self):
        return self.__fare

    # MUTATOR ================================================================
    def set_location(self, location):
        self.__location = location

    def set_time(self, time):
        self.__time = time

    def set_date(self, new):
        self.__date = new

    def set_fare(self, fare):
        self.__fare = fare

    # FUNCTIONS ================================================================
    def deleted_by(self, user):
        self.__deleted_by = user

    def completed(self):
        self.__completed = 'Completed'
