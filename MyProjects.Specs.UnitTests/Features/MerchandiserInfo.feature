Feature: MerchandiserInfo
	In order to sell policies to customers 
	users need to enter a valid office code and merch code 
	to view a list of bouquets to sell

Scenario Outline: Return bouquets for office code and merch code where
	Given that the user is logged in	
    When user enters the '<OfficeCode>' '<MerchCode>'	
    Then the result should match '<OfficeCodeValidationResponse>' '<MerchCodeValidationResponse>' <BouquetCount> <OfficeCodeIsValid> <MerchCodeIsValid> <OfficeCodeExists> <MerchCodeExists> <OfficeCodeIsActive> <MerchCodeIsActive>

	Examples: 
	| CaseName               | OfficeCodeValidationResponse | MerchCodeValidationResponse | BouquetCount | OfficeCode | MerchCode | OfficeCodeIsValid | MerchCodeIsValid | OfficeCodeExists | MerchCodeExists | OfficeCodeIsActive | MerchCodeIsActive |
	| InvalidOfficeCode      | InvalidOfficeCode            | NoMerchCode                 | 0            | 000        |           | false             | false            | false            | false           | false              | false             |
	| InactiveOfficeCode     | InactiveOfficeCode           | NoMerchCode                 | 0            | 000002     |           | true              | false            | true             | false           | false              | false             |
	| OfficeCodeDoesNotExist | OfficeCodeDoesNotExist       | NoMerchCode                 | 0            | 965652     |           | true              | false            | false            | false           | false              | false             |
	| NoMerchCode            | Valid                        | NoMerchCode                 | 0            | 000000     |           | true              | false            | true             | false           | true               | false             |
	| InvalidMerchCode       | NoOfficeCode                 | InvalidMerchCode            | 0            |            | 000       | false             | false            | false            | false           | false              | false             |
	| InactiveMerchCode      | NoOfficeCode                 | InactiveMerchCode           | 0            |            | 000001    | false             | true             | false            | true            | false              | false             |
	| MerchCodeDoesNotExist  | NoOfficeCode                 | MerchCodeDoesNotExist       | 0            |            | 654634    | false             | true             | false            | false           | false              | false             |
	| NoOfficeCode           | NoOfficeCode                 | Valid                       | 0            |            | 000000    | false             | true             | false            | true            | false              | true              |
	| Valid                  | Valid                        | Valid                       | 2            | 000000     | 000000    | true              | true             | true             | true            | true               | true              |