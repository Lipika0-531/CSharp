## BankAccount Class
The BankAccount class serves as the foundation for all types of bank accounts. It includes the following attributes:

**Properties:**

**AccountNumber (string):** This property holds the unique account number associated with the bank account.

**Balance (decimal):** This property stores the current balance of the account.

**Methods:**

**Deposit(amount):** This method enables account holders to deposit a specific amount into their account. The deposited amount is added to the current balance.

**Withdraw(amount):** This method allows account holders to withdraw a certain amount from their account. The withdrawn amount is subtracted from the current balance.

## SavingsAccount Class
The SavingsAccount class is derived from the BankAccount class. It inherits all properties and methods from the base class and adds specific behavior for savings accounts:

**Withdraw() Method Override:**

The Withdraw() method in the SavingsAccount class is overridden to enforce a restriction on withdrawals. If the withdrawal amount exceeds the current balance, the withdrawal is not allowed. This ensures that the account balance does not fall below a certain minimum balance.

## CheckingAccount Class
The CheckingAccount class is another derived class of BankAccount, inheriting the properties and methods of the base class:

**Withdraw() Method Override:**
The Withdraw() method in the CheckingAccount class is also overridden. However, unlike the SavingsAccount, the CheckingAccount allows withdrawals without any restrictions. Account holders can withdraw any amount, regardless of the current balance.