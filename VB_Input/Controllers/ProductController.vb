Imports System.Net
Imports System.Web.Http
Imports System.Data.SqlClient

Public Class ProductController
    Inherits ApiController

    <HttpPost>
    Public Function AddStock(ByVal stock As StockItem) As IHttpActionResult

        Dim productName As String = stock.ProductName
        Dim Price As Integer = stock.Price
        Dim Quantity As Integer = stock.Quantity
        Dim Status As Integer = stock.Status

        Dim connectionString As String = "Server=.\SQLEXPRESS;Database=Stock_T;User Id=sa;Password=123456;TrustServerCertificate=true"


        Dim sqlInsert As String = "INSERT INTO Tbl_Product (Product_Name, Price,Quantity,Status) VALUES (@Product_Name, @Price,@Quantity,@Status)"


        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(sqlInsert, connection)
                command.Parameters.AddWithValue("@Product_Name", productName)
                command.Parameters.AddWithValue("@Price", Price)
                command.Parameters.AddWithValue("@Quantity", Quantity)
                command.Parameters.AddWithValue("@Status", Status)

                connection.Open()


                command.ExecuteNonQuery()
            End Using
        End Using

        Return Ok()
    End Function
End Class

Public Class StockItem
    Public Property ProductName As String
    Public Property Price As Integer
    Public Property Quantity As Integer
    Public Property Status As Integer

End Class
