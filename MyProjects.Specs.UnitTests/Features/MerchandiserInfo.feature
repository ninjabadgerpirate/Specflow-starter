Feature: MerchandiserInfo
	In order to sell policies to customers 
	users need to enter an active office code and merch code 
	to view a list of bouquets to sell

Scenario Outline: Display bouquets that can be sold based on office code and merch code
	Given that the user is logged in	
    When user enters the '<OfficeCode>' '<MerchCode>'	
    Then the result should match '<Response>' <BouquetCount> <OfficeCodeIsValid> <MerchCodeIsValid> <OfficeCodeExists> <MerchCodeExists> <OfficeCodeIsActive> <MerchCodeIsActive>

	Examples: 
	| Response              | BouquetCount | OfficeCode | MerchCode | OfficeCodeIsValid | MerchCodeIsValid | OfficeCodeExists | MerchCodeExists | OfficeCodeIsActive | MerchCodeIsActive |
	| InvalidOfficeCode     | 0            | 000        |           | false             | false            | false            | false           | false              | false             |
	| InactiveOfficeCode    | 0            | 000002     |           | true              | false            | true             | false           | false              | false             |
	| OfficeCodeDoesnotExist| 0            | 965652     |           | true              | false            | false            | false           | false              | false             |
	| NoMerchCode           | 0            | 000000     |           | true              | false            | true             | false           | true               | false             |
	| InvalidMerchCode      | 0            |            | 000       | false             | false            | false            | false           | false              | false             |
	| InactiveMerchCode     | 0            |            | 000001    | false             | true             | false            | true            | false              | false             |
	| MerchCodeDoesNotExist | 0            |            | 654634    | false             | true             | false            | false           | false              | false             |
	| NoOfficeCode          | 0            |            | 000000    | false             | true             | false            | true            | false              | true              |
	| Valid                 | 2            | 000000     | 000000    | true              | true             | true             | true            | true               | true              |