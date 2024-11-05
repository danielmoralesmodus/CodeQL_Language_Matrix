import java.io.*;
import javax.servlet.*;
import javax.servlet.http.*;

public class FooServlet extends HttpServlet {
  protected void doGet(HttpServletRequest request, HttpServletResponse response)
  throws ServletException, IOException {
    // String cardSecurityCode = "12345";
    // User provided value
    String cardSecurityCode = request.getParameter("cardSecurityCode");
    Runtime.getRuntime().exec("validateCode.sh " + cardSecurityCode);
  }
}
