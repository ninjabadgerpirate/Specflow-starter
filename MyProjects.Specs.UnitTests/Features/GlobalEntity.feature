Feature: GlobalEntity
	In order to tie policies to customer accounts we need to 
	use a customer's South African Government ID to load their existing account
	or we need to create a new account using their South African Government ID.

Scenario Outline: Load an account using GovID
	Given that the user wants to load a customers account	
	When the user enters '<GovID>'
	Then the result should be '<GovIDValidationResponse>' '<GovIDExceptionStatus>' '<FirstNames>' '<Surname>' '<PreferredName>' '<Passport>' '<CountryID>' '<LUCPreferredLanguage>' '<LUCMaritalStatus>' '<EmployerName>' '<EmployeeNo>' '<LUCIncomeCategory>' <IsStaff> '<LUCTitle>' '<SalaryPayDay>'

	Examples: 
	| CaseName           | GovID         | GovIDValidationResponse     | GovIDExceptionStatus| FirstNames	| Surname	| PreferredName | Passport | CountryID | LUCPreferredLanguage | LUCMaritalStatus | EmployerName										| EmployeeNo | SalaryPayDay | LUCIncomeCategory | IsStaff | LUCTitle |
	| NoGovID            |               | NoGovID					   | NoException		 |				|			|               |          |           |                      |                  |													|            |              |                   | false   |          |
	| GovIDIsInvalid     | 80            | Invalid					   | NoException		 |				|			|               |          |           |                      |                  |													|            |              |                   | false   |          |
	| GovIDIsBlacklisted | 8611230945087 | Valid					   | Blacklisted		 | PHUMZA		| GQOTSA	|               |          | ZA        | en                   | Married          | DEPARTMENT OF ARLTICULTURE ANDFOREST FISHERIES	|            | 31           | 5 001 - 10 000    | false   | Mrs.     |
	| GovIDIsNew         | 8009135069089 | Valid					   | NoException		 |				|			|               |          |           |                      |                  |													|            |              |                   | false   |			 |
	| GovIDIsExisting    | 8801315607088 | Valid					   | NoException		 |MABUTHESIZWE	| NXUMALO   |               |          | ZA        | en                   | Not Married      | STUDENT											|            |  15          | Unknown           | false   | Mrs.     |