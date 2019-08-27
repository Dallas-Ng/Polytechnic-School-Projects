# OOP Project

## Required Modules: 
``pip install Flask ``

``pip install Flask-Bootstrap``

``pip install WTForms``


## Language
| Language  | Uses  |
|--|--|
| Python  | Database manipulation |
| Html | Website Creation to assist the program|
| Javascript | Website elements |


## Logins
| # | Username  | Password  |
|--|--|--|
| Admin | admin  | admin  |
| 1 | Danial_lim | danialpassword |
| 2 | Johnr23 | johnr23 |
| 3 | Tester | Tester |


##
## Features - Dallas

 `// Admin features are prefixed with /A/`

#### CRUD #1 - Sign in / Log in
	Features
		1) Logging in and Sign Up are both on a modal
		2) Log out button on each webpage
		3) Logging out and signing will trigger a function to record last seen so that its updated 
			on the overview page.
	Validations
		1) Username on creation will be defaulted to lower caps.
		2) When signing in password will be validated.
		3) When creating account, email must be formatted, username must be more than 6 characters and
			passwords must match.
		4) On Sign in, username can be capitalised, but password must be exactly the same on sign up.
		5) After logging out, clicking to go back will not allow you to view the page without signing in again.

#### CRUD #2 - Particulars
	Features
		1) Particulars of the user's account can be edited only by the same user
		2) /A/ Particulars of ANY account can be edited by an admin
	Validations
		1) Checks email and others
		2) Passwords must be the same

#### CRUD #3 - Booking
		Features
			1) Bookings Creation / Edit / Deletion
			2) Bookings will create a barcode to allow the user to scan when boarding the car
			3) Fares are calculated by location only, 
				[Yishun-10, Woodlands-2, Yio Chu Kang-4, Ang Mo Kio-5]
			3) Bookings can be sorted by [All, Today, Today Complete, Today Uncomplete, Past, Future]
			4) Viewing past bookings will allow you to create a feedback for that booking
			5) /A/Bookings can be undeleted by admin
			6) /A/ Admins can mark a booking as complete
			7) /A/ Admins are able to see ALL bookings

		Validations
			1) Checks if you have money before booking (After registration ++)
			2) Checks if you have a school before booking
			3) Checks if you have enough money before booking
			4) Checks if you are double booking the same date and time
			5) Checks if you are booking over 9pm or before 8am
			6) Checks if you are booking before the current time and date
			7) When editing, it will check if you are editing to the same date and time of a made booking
			8) Editing a booking gets disabled the day of the booking and before

##### CRUD #4 - Information Updates
	Features
		1) Updates are displayed only on the overview page and booking home page
	Validations
		1) If Admin enters '/n', it will default to 'No Changes'
