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
		3) Logging out and signing will trigger a function to record last seen so that its updated on the overview page.
	Validations
		1) Username on creation will be defaulted to lower caps.
		2) When signing in password will be validated.
		3) When creating account, email must be formatted, username must be more than 6 characters and passwords must match.
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
			3) Fares are calculated by location only, [Yishun-10, Woodlands-2, Yio Chu Kang-4, Ang Mo Kio-5]
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

##
## Randy's features

#### CRUD #1: Wallet balance
- Features
	1. User able to check wallet balance and top-up 
	2. Amount not able to deduct if there is no assigned credit card
	3. User able to read transaction history 
- Validations
	1. Ensure that there are 16 digits for card number input
	2. Ensure that there are 3 digits for ccv number input
	3. Ensure all inputs are required 

#### CRUD #2: Point system
- Features
	1. User able to read current points available
	2. Points are updated if there are any point rewards/ deduction
- Validations
	1. Alert is being displayed if insufficient points

#### CRUD #3: Overview
- Features
	1. Admin able to read all user's name, wallets and points
	2. Admin able to update points of user by deducting or adding points
	3. Admin able to update wallet of user by deducting or adding amount
- Validations
	1. Admin not able to deduct points or amount in wallet if balance is lower than 0

##
## Tjandra's features

#### CRUD #1 - Admin Feedback Overview
- Features
	1. Feedback can be sorted by [All,Months,Years]
	2. Feedback can be deleted

#### CRUD #2 - Admin Reminder
-	Features
	1. Reminder can be created and displayed
	2. Editing reminder will open up a modal on the same page
	3. Reminder can be deleted
	4. Reminder status can be marked as "Important" or "Not Important".
-	Validations
	1. Check for empty field

##
## Faris' Features

#### CRUD #1: Feedback form 
- Features
	1. Allows user to create feedback
- Validations
	1. All questions must be answered, otherwise 'This field is required' will be shown at the unanswered question

#### CRUD #2: Lost and found form
-	Features
	1. Allows user to create lost and found
	2. Allows admin to read lost and found items of users via Admin page
	3. Allows admin to update 'Status' of Lost and found item
	4. Allows admin to delete Lost and found item 
- Validations
	1. All fields required for user to key in
