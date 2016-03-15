ModelViews "ViewModels" are used as a security filter they are an abstraction from the concrete class.

I used ModelViews opposed to ViewModels, simply because the file is placed directly after the Model folder.

/******************************************************************************/
					 Concrete Class Examples
/******************************************************************************/
class Person
{
	public int PersonID { get; set; }
	public string PersonName { get; set; }

	public virtual ICollection<ProFile> ProFiles { get; protected; }
	//Other MetaData Properties
}

class BankClient
{
	public int BankClientID { get; set; }
	public int ProFileID { get; set; }
 
	public BankCard BankCard { get; protected; }
	public virtual BankAccount BankAccount { get; protected; }
}

class BankAccount
{
	public int BankAccountID { get; set; }
	public string BankAccountType { get; set; }

	public virtual Bank Bank { get; protected; }
	public virtual ICollection<BankClient> BankClients { get; protected; }
}

class BankCard
{
	public int BankAccountID { get; set; }
	public int BankCardSerialNumber { get; protected; }
	public Date Expiration { get; set;}
}

class Bank
{
	public int BankID { get; set; }
	public string BankName { get; set; }
	public DbGeography Location { get; set; }
}
/******************************************************************************/
						ModelViews SetUp Examples
/******************************************************************************/

"ModelView" or "ViewModel" //undecided naming convention

class ClientView // currently convention is "ModelView"
{
	public int ClientViewID { get; set; }
	public string ClientViewName { get; set; }

	public int BankCardSerialNumber { get; set; }

	
}