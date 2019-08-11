"""
Written by:
Dallas 180522Y
Faris 182915N
"""
from properties.external.shelving.inherit import *
from properties.external.library_python.functions import *
from properties.external.library_python.form import *
import datetime


class LostAndFound(InheritThis):
    def __init__(self, username, description, item, date, status, time):
        super().__init__(username)
        lost_and_found_id = str(datetime.datetime.now().timestamp())
        self.__lost_and_found_id = lost_and_found_id
        self.__description = description
        self.__status = status
        self.__item = item
        self.__date = date
        self.__time = time

    def get_description(self):
        return self.__description

    def get_date(self):
        return self.__date

    def get_item(self):
        return self.__item

    def get_status(self):
        return self.__status

    def get_time(self):
        return self.__time

    def get_lost_and_found_id(self):
        return self.__lost_and_found_id

    def set_status(self, status):
        self.__status = status
