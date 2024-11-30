using System;
using System.Data.SqlClient;
using System.Web.UI;
namespace YourNamespace
{
public partial class AddProduct : Page{
protected void btnSubmit_Click(object sender, EventArgs e)
{
if (Page.IsValid)
{
string name = txtName.Text.Trim();
decimal amount;
int stock;
if (Decimal.TryParse(txtAmount.Text, out amount) && amount > 0 &&
Int32.TryParse(txtStock.Text, out stock) && stock >= 0)
{
try
{
string connectionString = "DataSource=localhost; Initial Catalog=TestDB; User ID=Naveen; Password=Test@123;";
using (SqlConnection connection = new
SqlConnection(connectionString))
{
string query = "INSERT INTO Product (Name, Amount, Stock)
VALUES (@Name, @Amount, @Stock)";
using (SqlCommand command = new SqlCommand(query,
connection))
{
command.Parameters.AddWithValue("@Name", name);
command.Parameters.AddWithValue("@Amount", amount);
command.Parameters.AddWithValue("@Stock", stock);
}
}
connection.Open();
command.ExecuteNonQuery();
connection.Close();
Response.Write("<script>alert('Product added
successfully!');</script>");
}
catch (Exception ex)
{
}
}
else
{
Response.Write("<script>alert('Error: " + ex.Message + "');</script>");Response.Write("<script>alert('Invalid input for Amount or
Stock.');</script>");
}
}
}
}
}
