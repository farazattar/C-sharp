// C++ program for connecting to database (and error handling)
#include<stdio.h>
#include<SQLAPI.h>		 // main SQLAPI++ header

int main(int argc, char* argv[])
{
	// create connection object to connect to database
	SAConnection con;
	try 
	{
		// connect to database
		// in this example, it is Oracle,
		// but can also be Sybase, Informix, DB2
		// SQLServer, InterBase, SQLBase and ODBC
		con.Connect(_TSA("Test"), _TSA("postgres"), _TSA("Postgres@Dcs"), SA_PostgreSQL_Client);
		printf("We are connected!\n");

		// Disconnect is optional
		// autodisconnect will occur in destructor if needed
		con.Disconnect();
		printf("We are disconnected!\n");
	}

	catch(SAException & x)
	{
		// SAConnection::Rollback()
		// can also throw an exception
		// (if a network error for example),
		// we will be ready
		try
		{
			// on error rollback changes
			con.Rollback ();
		}
		catch(SAException &)
		{
		}
		// print error message
		printf("%s\n", (const char*)x.ErrText());
	}
	system("pause");
	return 0;
}
