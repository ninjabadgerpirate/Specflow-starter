Feature: GlobalEntity
	In order to tie policies to customer accounts we need to 
	use a customer's South African Government ID to load their existing account
	or we need to create a new account using their South African Government ID.

Scenario Outline: Load an account using GovID
	Given that the user wants to load a customers account	
	When the user enters '<GovID>'
	Then the result should be <IsValid> '<Status>' '<FirstNames>' '<Surname>' '<PreferredName>' '<Passport>' '<CountryID>' '<LUCPreferredLanguage>' '<LUCMaritalStatus>' '<EmployerName>' '<EmployeeNo>' '<LUCIncomeCategory>' '<IsStaff>' '<LUCTitle>' '<SalaryPayDay>'

	Examples: 
	| CaseName           | GovID         | IsValid     | Status			| FirstNames	| Surname	| PreferredName | Passport | CountryID | LUCPreferredLanguage | LUCMaritalStatus | EmployerName										| EmployeeNo | SalaryPayDay | LUCIncomeCategory | IsStaff | LUCTitle |
	| NoGovID            |               | false       | Invalid		|				|			|               |          |           |                      |                  |													|            |              |                   |         |          |
	| GovIDIsInvalid     | 80            | false       | Invalid		|				|			|               |          |           |                      |                  |													|            |              |                   |         |          |
	| GovIDIsBlacklisted | 8611230945087 | true		   | Blacklisted    | PHUMZA		| GQOTSA	|               |          | ZA        | en                   | Married          | DEPARTMENT OF ARLTICULTURE ANDFOREST FISHERIES	|            | 31           | 5 001 - 10 000    | 0       | Mrs.     |
	| GovIDIsNew         | 8009135069089 | true        | New			|				|			|               |          |           |                      |                  |													|            |              |                   |         |			 |
	| GovIDIsExisting    | 8801315607088 | true		   | Existing		|MABUTHESIZWE	| NXUMALO   |               |          | ZA        | en                   | Not Married      | STUDENT											|            |  15          | Unknown           |  0      |          |