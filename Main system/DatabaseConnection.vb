﻿Imports MySql.Data.MySqlClient

Module DatabaseConnection

    Public con As New MySqlConnection

    Sub DBCon()
        con.ConnectionString = "server=localhost;username=root;password=new_password;database=infiniteeth"
        con.Open()
    End Sub

End Module
