"""
Written by:
Dallas 180522Y
"""


# ALLOWS ALL CLASS TO HAVE GET_USERNAME
class InheritThis:
    def __init__(self, username):
        self.__username = username

    def get_username(self):
        return self.__username
