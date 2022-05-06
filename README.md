Build on C# .netcore 6.0
Unit testing C# with NUnit and .NET Core

# POSTerminal
  Technical Exercise : Library for POS Ordering, Scan Product and Return Total Calculated Unit Price and Bulk Price. 
 
Here are the requirements:

Consider a grocery market where items have prices per unit but also volume prices. For example, doughnuts may be $1.25 each or 3 for $3 dollars. There could only be a single volume discount per product.

Implement a point-of-sale scanning API (library) that accepts an arbitrary ordering of products (similar to what would happen when actually at a checkout line) then returns the correct total price for an entire shopping cart based on the per unit prices or the volume prices as applicable.

Here are the products listed by code and the prices to use (there is no sales tax):
Product Code	Price
A	$1.25 each or 3 for $3.00
B	$4.25
C	$1.00 or $5 for a six pack
D	$0.75

Here are the minimal inputs you should use for your test cases. These test cases must be shown to work in your program:
1. Scan these items in this order: ABCDABA; Verify the total price is $13.25.
2. Scan these items in this order: CCCCCCC; Verify the total price is $6.00.
3. Scan these items in this order: ABCD; Verify the total price is $7.25

 
