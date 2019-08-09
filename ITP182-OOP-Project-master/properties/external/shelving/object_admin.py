"""
Written by:
Dallas 180522Y
Tjandra 181110B
"""
from properties.external.shelving.inherit import *
from properties.external.library_python.functions import *
from properties.external.library_python.form import *

import datetime


class Reminder(InheritThis):
    def __init__(self, username, name, information):
        super().__init__(username)
        reminder_id = str(datetime.datetime.now().timestamp())
        self.__reminder_id = reminder_id
        self.__name = name
        self.__information = information
        self.__important = '-'

    def get_reminder_id(self):
        return self.__reminder_id

    def get_name(self):
        return self.__name

    def get_information(self):
        return self.__information

    def get_important_status(self):
        return self.__important

    def set_name(self, name):
        self.__name = name

    def set_information(self, info):
        self.__information = info


# FUNCTIONS ================================================================

    def important(self):
        self.__important = 'Important'

    def notimportant(self):
        self.__important = '-'
