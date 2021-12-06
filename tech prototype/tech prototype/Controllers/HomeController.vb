Public Class HomeController
    Inherits System.Web.Mvc.Controller

    Function Index() As ActionResult
        Return View()
    End Function

    Function About() As ActionResult
        ViewData("Message") = "Your application description page."

        Return View()
    End Function

    Function Contact() As ActionResult
        ViewData("Message") = "Your contact page."

        Return View()
    End Function
    Function SavedATM() As ActionResult
        ViewData("Message") = "Your Saved ATM."

        Return View()
    End Function
    Function SearchATM() As ActionResult
        ViewData("Message") = "Search ATM."

        Return View()
    End Function
End Class
