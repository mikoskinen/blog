Imports System.Xml.Linq

Public Class Generator

    Public Shared Function Generate(title As String, time As DateTime) As XElement

        Dim element = <tile><visual><binding template="TileWideText09"><text id="1"><%= title %></text><text id="2"><%= time.ToString() %></text></binding><binding template="TileSquareText04"><text id="1"><%= title %></text></binding></visual></tile>

        Return element

    End Function

End Class
