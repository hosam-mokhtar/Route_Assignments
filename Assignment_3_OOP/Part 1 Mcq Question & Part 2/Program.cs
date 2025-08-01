namespace Part_1_Mcq_Question___Part_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Part 01
            #region Question 1:
            //What is the primary purpose of an interface in C#?
            //a) To provide a way to implement multiple inheritance        
            //b) To define a blueprint for a class                                   // Answer(b)
            //c) To declare abstract methods and properties
            //d) To create instances of objects

            #endregion

            #region Question 2:
            //Which of the following is NOT a valid access modifier for interface members in C#?
            //a) private                                                             // Answer(a)
            //b) protected
            //c) internal
            //d) public

            #endregion

            #region Question 3:
            //Can an interface contain fields in C#?
            //a) Yes                                         
            //b) No                                                                 // Answer(b)
            //c) Only if they are static
            //d) Only if they are readonly

            #endregion

            #region Question 4:
            //In C#, can an interface inherit from another interface?
            //a) No, interfaces cannot inherit from each other
            //b) Yes, interfaces can inherit from multiple interfaces               // Answer(b)
            //c) Yes, but only if they have the same methods
            //d) Only if the interfaces are in the same namespace

            #endregion

            #region Question 5:
            //Which keyword is used to implement an interface in a class in C#?
            //a) inherit
            //b) use
            //c) extends
<<<<<<< Updated upstream
            //d) implements                                                        // Answer(d) =>  : colon
=======
            //d) implements                                                        // Answer(d)  : colon
>>>>>>> Stashed changes

            #endregion

            #region Question 6:
            //Can an interface contain static methods in C#?
            //a) Yes                                                              // Answer(a)
            //b) No
            //c) Only if the interface is sealed
            //d) Only if the methods are private

            #endregion

            #region Question 7:
            //In C#, can an interface have explicit access modifiers for its members?
            //a) Yes, for all members
            //b) No, all members are implicitly public                           // Answer(b)
            //c) Yes, but only for abstract members
            //d) Only if the interface is sealed

            #endregion

            #region Question 8:
            //What is the purpose of an explicit interface implementation in C#?
            //a) To hide the interface members from outside access              // Answer(a)
            //b) To provide a clear separation between interface and class members
            //c) To allow multiple classes to implement the same interface
            //d) To speed up method resolution

            #endregion

            #region Question 9:
            //In C#, can an interface have a constructor?
            //a) Yes, but it must be private
            //b) No, interfaces cannot have constructors                        // Answer(b)
            //c) Yes, but only if the interface is sealed
            //d) Only if the constructor is static

            #endregion

            #region Question 10:
            //How can a C# class implement multiple interfaces?
            //a) By using the "implements" keyword
            //b) By using the "extends" keyword
            //c) By separating interface names with commas                      // Answer(c)
            //d) A class cannot implement multiple interfaces

            #endregion
            #endregion

            #region Part 02
            #region   Question 01:
            //Define an interface named IShape with a property Area and a method DisplayShapeInfo.
            //Create two interfaces, ICircle and IRectangle, that inherit from IShape.
            //Implement these interfaces in classes Circle and Rectangle.
            //Test your implementation by creating instances of both classes and displaying their shape information.

<<<<<<< Updated upstream

            ICircle circle = new Circle(5.5);
            circle.DisplayShapeInfo();

            Console.WriteLine(new string('-', 40));

            // polymorphism
            IShape circle1 = circle;
            circle1.DisplayShapeInfo();

            Console.WriteLine(new string('-', 40));

            IRectangle rectangle = new Rectangle(20.5, 10.5);
            rectangle.DisplayShapeInfo();

            Console.WriteLine(new string('-', 40));

            // polymorphism
            IShape rectangle1 = rectangle;
            rectangle1.DisplayShapeInfo();
=======
            //Answer:

            //ICircle circle = new Circle(5.5);
            //circle.DisplayShapeInfo();

            //Console.WriteLine(new string('-', 40));

            //// polymorphism
            //IShape circle1 = circle;
            //circle1.DisplayShapeInfo();

            //Console.WriteLine(new string('-', 40));

            //IRectangle rectangle = new Rectangle(20.5, 10.5);
            //rectangle.DisplayShapeInfo();

            //Console.WriteLine(new string('-', 40));

            //// polymorphism
            //IShape rectangle1 = rectangle;
            //rectangle1.DisplayShapeInfo();
>>>>>>> Stashed changes


            #endregion

            #region Question 02:
<<<<<<< Updated upstream
            //In this example, we start by defining the IAuthenticationService interface with two methods: AuthenticateUser and AuthorizeUser.The BasicAuthenticationService class implements this interface and provides the specific implementation for these methods.
            //In the BasicAuthenticationService class, the AuthenticateUser method compares the provided username and password with the stored credentials.It returns true if the user is authenticated and false otherwise.The AuthorizeUser method checks if the user with the given username has the specified role.It returns true if the user is authorized and false otherwise.
            //In the Main method, we create an instance of the BasicAuthenticationService class and assign it to the authService variable of type IAuthenticationService.We then call the AuthenticateUser and AuthorizeUser methods using this interface reference.
            //This implementation allows you to switch the authentication service implementation easily by creating a new class that implements the IAuthenticationService interface and providing the desired logic for authentication and authorization.
=======
            //In this example, we start by defining the IAuthenticationService interface with two methods: AuthenticateUser and AuthorizeUser.
            //The BasicAuthenticationService class implements this interface and provides the specific implementation for these methods.
            //In the BasicAuthenticationService class, the AuthenticateUser method compares the provided username and password with the stored credentials.
            //It returns true if the user is authenticated and false otherwise.
            //The AuthorizeUser method checks if the user with the given username has the specified role.
            //It returns true if the user is authorized and false otherwise.
            //In the Main method, we create an instance of the BasicAuthenticationService class and assign it to the authService variable of type IAuthenticationService.
            //We then call the AuthenticateUser and AuthorizeUser methods using this interface reference.
            //This implementation allows you to switch the authentication service implementation easily by creating a new class
            //that implements the IAuthenticationService interface and providing the desired logic for authentication and authorization.

            //Answer:

            //string username = "mentor";
            //string password = "12345";
            //string role = "administrator";

            //IAuthenticationService authenticationService = new BasicAuthenticationService();
            //if (authenticationService.AuthenticateUser(username, password))
            //{
            //    Console.WriteLine($"Welcome {username}");
            //    if (authenticationService.AuthorizeUser(username, role))
            //    {
            //        Console.WriteLine($"{username} role is {role}");
            //    }
            //    else
            //    {
            //        Console.WriteLine($"Username {username} has no role");
            //    }
            //}
            //else
            //    Console.WriteLine($"Username {username} isn't exist.");

>>>>>>> Stashed changes

            #endregion

            #region Question 03:
            //we define the INotificationService interface with a method SendNotification that takes a recipient and a message as parameters.
<<<<<<< Updated upstream
            //We then create three classes: EmailNotificationService, SmsNotificationService, and PushNotificationService, which implement the INotificationService interface.
=======
            //We then create three classes: EmailNotificationService, SmsNotificationService, and PushNotificationService,
            //which implement the INotificationService interface.
>>>>>>> Stashed changes
            //In each implementation, we provide the logic to send notifications through the respective communication channel:
            //The EmailNotificationService class simulates sending an email by outputting a message to the console.
            //The SmsNotificationService class simulates sending an SMS by outputting a message to the console.
            //The PushNotificationService class simulates sending a push notification by outputting a message to the console.
<<<<<<< Updated upstream
            //In the Main method, we create instances of each notification service class and call the SendNotification method with sample recipient and message values.
            //This implementation allows you to easily switch between different notification channels by creating new classes that implement the INotificationService interface and provide the specific logic for each channel.
=======
            //In the Main method, we create instances of each notification service class and call the SendNotification method
            //with sample recipient and message values.
            //This implementation allows you to easily switch between different notification channels by creating new classes
            //that implement the INotificationService interface and provide the specific logic for each channel.

            //Answer:

            //INotificationService emailNotificationService = new EmailNotificationService();
            //emailNotificationService.SendNotification("hosam.fcis@gmail.com", "Congratulations...");

            //INotificationService smsNotificationService = new SmsNotificationService();
            //smsNotificationService.SendNotification("+201012345678", "You will recivied 10000 L.E.....");

            //INotificationService pushNotificationService = new PushNotificationService();
            //pushNotificationService.SendNotification("user1", "You have a new message.");
>>>>>>> Stashed changes

            #endregion
            #endregion
        }
    }
}
