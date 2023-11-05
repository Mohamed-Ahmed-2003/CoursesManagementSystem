using CoursesManagementSystem.Controllers;
using CoursesManagementSystem.Data;
using CoursesManagementSystem.Models;
using CoursesManagementSystem.Services.Interfaces;
using CoursesManagementSystem.ViewModels;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CoursesManagementSystem.Services
{
    public class Initializer
    {
        private static readonly  CategoryService categoryService = new CategoryService();
        private static readonly  CourseService courseService = new CourseService();
        private static readonly  TrainerService trainerService = new TrainerService();
        private static readonly TraineeCourseService traineeCourseService= new TraineeCourseService();
        private static readonly MyUserManager _userManager = new MyUserManager();

        public static void PopulateDB()
        {
            CreateCategoriesForFirstTime();
            CreateTrainersForFirstTime();
            CreateTraineesForFirstTime();
            CreateCoursesForFirstTime();
            CreateReviewsForFirstTime();


        }
        public static void CreateReviewsForFirstTime() {
            var TcModels = new TraineeCourse[]
            {
                new TraineeCourse
            {
                TraineeID = 1,
                CourseID = 1,
                EnrolledDate = DateTime.Now,
                Rating = 5,
                ReviewTitle = "A Fundamental Journey in Technology",
                ReviewDate = DateTime.Now,
                Review = "This course has been a fundamental journey in understanding technology. The content was well-organized, and the practical examples were eye-opening. Highly recommended!"
            },
            new TraineeCourse
            {
                TraineeID = 1,
                CourseID = 2,
                EnrolledDate = DateTime.Now,
                Rating = 4,
                ReviewTitle = "Diving Deep into Cutting-Edge Technology",
                ReviewDate = DateTime.Now,
                Review = "Diving deep into advanced topics like artificial intelligence and blockchain was truly mind-blowing. The course provided a unique perspective, and the real-world applications were insightful."
            },
            new TraineeCourse
            {
                TraineeID = 1,
                CourseID = 3,
                EnrolledDate = DateTime.Now,
                Rating = 5,
                ReviewTitle = "Unlocking the Secrets of DevOps Collaboration",
                ReviewDate = DateTime.Now,
                Review = "DevOps Foundations is a treasure trove of insights into collaboration between development and operations teams. The hands-on exercises were invaluable, and the real-world scenarios were eye-opening."
            },
            new TraineeCourse
            {
                TraineeID = 1,
                CourseID = 4,
                EnrolledDate = DateTime.Now,
                Rating = 4,
                ReviewTitle = "Mastering Practical Skills in Cloud Computing",
                ReviewDate = DateTime.Now,
                Review = "This course provided a mastery of practical skills in cloud computing. The hands-on exercises on popular cloud platforms were challenging, providing a solid foundation for real-world applications."
            },
            new TraineeCourse
            {
                TraineeID = 1,
                CourseID = 5,
                EnrolledDate = DateTime.Now,
                Rating = 5,
                ReviewTitle = "Staying Ahead in Cybersecurity",
                ReviewDate = DateTime.Now,
                Review = "Emerging Technologies in Cybersecurity ensured staying ahead of cyber threats. The comprehensive coverage of the latest trends and technologies provided a deep understanding of the cybersecurity landscape."
            },
            new TraineeCourse
            {
                TraineeID = 1,
                CourseID = 6,
                EnrolledDate = DateTime.Now,
                Rating = 4,
                ReviewTitle = "Building a Strong Foundation in Web Development",
                ReviewDate = DateTime.Now,
                Review = "Web Development Fundamentals laid a strong foundation for my journey in web development. The clear explanations and practical exercises enhanced my coding skills."
            },
            new TraineeCourse
            {
                TraineeID = 1,
                CourseID = 7,
                EnrolledDate = DateTime.Now,
                Rating = 5,
                ReviewTitle = "Crafting Responsive Web Design with CSS Frameworks",
                ReviewDate = DateTime.Now,
                Review = "Learning to create responsive and visually appealing web pages using CSS frameworks was an enriching experience. The practical insights into modern web design practices were highly valuable."
            },
            new TraineeCourse
            {
                TraineeID = 1,
                CourseID = 8,
                EnrolledDate = DateTime.Now,
                Rating = 4,
                ReviewTitle = "Unleashing Interactivity with JavaScript",
                ReviewDate = DateTime.Now,
                Review = "The course on JavaScript and Frontend Frameworks was an exploration into the power of JavaScript. The interactive elements covered in the course helped me understand how to build dynamic web applications."
            },
            new TraineeCourse
            {
                TraineeID = 1,
                CourseID = 9,
                EnrolledDate = DateTime.Now,
                Rating = 5,
                ReviewTitle = "Powerful Server-Side Applications with Node.js and Express",
                ReviewDate = DateTime.Now,
                Review = "Building powerful server-side applications using Node.js and the Express framework was an empowering experience. The hands-on practice provided valuable insights into developing scalable and efficient backend solutions."
            },
            new TraineeCourse
            {
                TraineeID = 1,
                CourseID = 10,
                EnrolledDate = DateTime.Now,
                Rating = 4,
                ReviewTitle = "A Comprehensive Journey in Full-Stack Web Development",
                ReviewDate = DateTime.Now.AddDays(7),
                Review = "The course on Full-Stack Web Development with MERN Stack was a comprehensive journey. The curriculum covered both frontend and backend aspects, providing a well-rounded understanding of full-stack development. I only wished for more practical exercises to reinforce learning."
            },
              new TraineeCourse
            {
                TraineeID = 2,
                CourseID = 11,
                EnrolledDate = DateTime.Now,
                Rating = 4,
                ReviewTitle = "Unlocking the World of UX/UI Fundamentals",
                ReviewDate = DateTime.Now,
                Review = "Exploring the foundational principles of UX/UI design was an enlightening experience. The course content was well-structured, and the practical exercises provided a solid understanding."
            },
            new TraineeCourse
            {
                TraineeID = 2,
                CourseID = 12,
                EnrolledDate = DateTime.Now,
                Rating = 5,
                ReviewTitle = "Creating Engaging Experiences with Interactive UI Design",
                ReviewDate = DateTime.Now,
                Review = "Diving into the world of interactive user interface design was fantastic. The course provided valuable insights into creating engaging digital experiences. Highly recommended!"
            },
            new TraineeCourse
            {
                TraineeID = 2,
                CourseID = 13,
                EnrolledDate = DateTime.Now,
                Rating = 4,
                ReviewTitle = "Statistical Mastery with Statistics Fundamentals",
                ReviewDate = DateTime.Now,
                Review = "Gaining a comprehensive understanding of statistics was invaluable. The course covered foundational principles with clarity, and the practical applications enhanced my statistical skills."
            },
            new TraineeCourse
            {
                TraineeID = 2,
                CourseID = 14,
                EnrolledDate = DateTime.Now,
                Rating = 5,
                ReviewTitle = "Mastering Calculus Principles",
                ReviewDate = DateTime.Now,
                Review = "Diving into the fundamental principles of calculus was a challenging yet rewarding journey. The course provided a solid foundation, and the examples helped in mastering calculus principles."
            },
            new TraineeCourse
            {
                TraineeID = 2,
                CourseID = 15,
                EnrolledDate = DateTime.Now,
                Rating = 4,
                ReviewTitle = "Algebra Basics - A Strong Foundation",
                ReviewDate = DateTime.Now,
                Review = "Building a strong foundation in algebraic concepts was a great learning experience. The course content was well-organized, and the practical exercises provided a solid understanding of algebra basics."
            },
            new TraineeCourse
            {
                TraineeID = 2,
                CourseID = 16,
                EnrolledDate = DateTime.Now,
                Rating = 5,
                ReviewTitle = "Exploring the World of Painting",
                ReviewDate = DateTime.Now,
                Review = "Exploring the world of visual arts and developing painting skills was an enriching experience. The course content was engaging, and the practical exercises enhanced my painting techniques."
            },
            new TraineeCourse
            {
                TraineeID = 2,
                CourseID = 17,
                EnrolledDate = DateTime.Now,
                Rating = 4,
                ReviewTitle = "Comprehensive Understanding of Biology Fundamentals",
                ReviewDate = DateTime.Now,
                Review = "Gaining a comprehensive understanding of fundamental biological concepts was insightful. The course content was well-structured, and the practical applications enhanced my knowledge of biology fundamentals."
            },
            new TraineeCourse
            {
                TraineeID = 2,
                CourseID = 18,
                EnrolledDate = DateTime.Now,
                Rating = 5,
                ReviewTitle = "Exploring the Fundamentals of Physics",
                ReviewDate = DateTime.Now,
                Review = "Exploring the fundamental principles of physics and their applications was fascinating. The course content was clear, and the practical examples provided a deep understanding of physics fundamentals."
            },
            new TraineeCourse
            {
                TraineeID = 2,
                CourseID = 19,
                EnrolledDate = DateTime.Now,
                Rating = 4,
                ReviewTitle = "Chemistry Fundamentals - A Comprehensive Overview",
                ReviewDate = DateTime.Now,
                Review = "Exploring the basic principles of chemistry and chemical reactions was comprehensive. The course content was well-organized, and the practical applications enhanced my understanding of chemistry fundamentals."
            },
            new TraineeCourse
            {
                TraineeID = 2,
                CourseID = 5,
                EnrolledDate = DateTime.Now,
                Rating = 5,
                ReviewTitle = "Emerging Technologies in Cybersecurity - A Must-Take",
                ReviewDate = DateTime.Now,
                Review = "Staying ahead of cyber threats with Emerging Technologies in Cybersecurity was a must-take experience. The course covered the latest trends and technologies, providing a comprehensive understanding of the cybersecurity landscape."
            },
             new TraineeCourse
            {
                TraineeID = 3,
                CourseID = 1,
                EnrolledDate = DateTime.Now,
                Rating = 4,
                ReviewTitle = "Solid Introduction to Technology Fundamentals",
                ReviewDate = DateTime.Now,
                Review = "The introduction to technology fundamentals was solid. The course content was well-explained, and the practical examples helped in understanding key concepts."
            },
            new TraineeCourse
            {
                TraineeID = 3,
                CourseID = 3,
                EnrolledDate = DateTime.Now,
                Rating = 5,
                ReviewTitle = "DevOps Foundations - A Collaborative Journey",
                ReviewDate = DateTime.Now,
                Review = "DevOps Foundations provided a collaborative journey into understanding the principles and practices of DevOps. The real-world scenarios were enlightening, and the hands-on exercises enhanced my skills."
            },
            new TraineeCourse
            {
                TraineeID = 3,
                CourseID = 5,
                EnrolledDate = DateTime.Now,
                Rating = 4,
                ReviewTitle = "Emerging Technologies in Cybersecurity - Stay Informed",
                ReviewDate = DateTime.Now,
                Review = "Emerging Technologies in Cybersecurity helped me stay informed about the latest trends and technologies in cybersecurity. The comprehensive coverage provided a deep understanding of the cybersecurity landscape."
            },
            new TraineeCourse
            {
                TraineeID = 3,
                CourseID = 7,
                EnrolledDate = DateTime.Now,
                Rating = 3,
                ReviewTitle = "Responsive Web Design and CSS Frameworks - Room for Improvement",
                ReviewDate = DateTime.Now,
                Review = "While Responsive Web Design and CSS Frameworks covered essential concepts, there is room for improvement in the practical exercises. The theoretical understanding was good, but more hands-on practice would be beneficial."
            },
            new TraineeCourse
            {
                TraineeID = 3,
                CourseID = 9,
                EnrolledDate = DateTime.Now,
                Rating = 4,
                ReviewTitle = "Backend Development with Node.js and Express - Building Powerful Applications",
                ReviewDate = DateTime.Now,
                Review = "Backend Development with Node.js and Express provided valuable insights into building powerful server-side applications. The hands-on experience enhanced my understanding of scalable and efficient backend solutions."
            },
            new TraineeCourse
            {
                TraineeID = 3,
                CourseID = 11,
                EnrolledDate = DateTime.Now,
                Rating = 5,
                ReviewTitle = "UX/UI Fundamentals - Design Excellence",
                ReviewDate = DateTime.Now,
                Review = "Exploring the foundational principles of UX/UI design was an enlightening experience. The course content was well-structured, and the practical exercises provided a solid understanding."
            },
            new TraineeCourse
            {
                TraineeID = 3,
                CourseID = 13,
                EnrolledDate = DateTime.Now,
                Rating = 4,
                ReviewTitle = "Statistics Fundamentals - Practical Knowledge",
                ReviewDate = DateTime.Now,
                Review = "Gaining practical knowledge in Statistics Fundamentals was valuable. The course content was clear, and the real-world applications enhanced my statistical skills."
            },
            new TraineeCourse
            {
                TraineeID = 3,
                CourseID = 15,
                EnrolledDate = DateTime.Now,
                Rating = 3,
                ReviewTitle = "Algebra Basics - Foundational Learning",
                ReviewDate = DateTime.Now,
                Review = "While Algebra Basics provided foundational learning, the theoretical approach could be supplemented with more practical exercises. However, the content was clear and informative."
            },
            new TraineeCourse
            {
                TraineeID = 3,
                CourseID = 17,
                EnrolledDate = DateTime.Now,
                Rating = 5,
                ReviewTitle = "Biology Fundamentals - Comprehensive Understanding",
                ReviewDate = DateTime.Now,
                Review = "Biology Fundamentals provided a comprehensive understanding of fundamental biological concepts. The course content was well-organized, and the practical applications enhanced my knowledge."
            },
            new TraineeCourse
            {
                TraineeID = 3,
                CourseID = 19,
                EnrolledDate = DateTime.Now,
                Rating = 4,
                ReviewTitle = "Chemistry Fundamentals - Solid Overview",
                ReviewDate = DateTime.Now,
                Review = "Chemistry Fundamentals offered a solid overview of basic principles and chemical reactions. The content was well-structured, providing a good foundation in chemistry."
            },
             new TraineeCourse
            {
                TraineeID = 4,
                CourseID = 2,
                EnrolledDate = DateTime.Now,
                Rating = 5,
                ReviewTitle = "Advanced Topics in Technology Innovation - Exceptional Insights",
                ReviewDate = DateTime.Now,
                Review = "Advanced Topics in Technology Innovation provided exceptional insights into cutting-edge technologies like artificial intelligence and blockchain. The course content was advanced yet accessible, making it a valuable learning experience."
            },
            new TraineeCourse
            {
                TraineeID = 4,
                CourseID = 4,
                EnrolledDate = DateTime.Now,
                Rating = 4,
                ReviewTitle = "Cloud Computing Essentials - Practical Applications",
                ReviewDate = DateTime.Now,
                Review = "Cloud Computing Essentials offered practical applications of cloud computing principles. The hands-on exercises were beneficial, providing a good balance between theory and practice."
            },
            new TraineeCourse
            {
                TraineeID = 4,
                CourseID = 6,
                EnrolledDate = DateTime.Now,
                Rating = 5,
                ReviewTitle = "Web Development Fundamentals - Strong Learning Path",
                ReviewDate = DateTime.Now,
                Review = "Web Development Fundamentals offered a strong learning path in web development. The course content was comprehensive, and the hands-on exercises were beneficial for building foundational skills."
            },
            new TraineeCourse
            {
                TraineeID = 4,
                CourseID = 8,
                EnrolledDate = DateTime.Now,
                Rating = 4,
                ReviewTitle = "JavaScript and Frontend Frameworks - Interactive Experience",
                ReviewDate = DateTime.Now,
                Review = "JavaScript and Frontend Frameworks provided an interactive learning experience. The practical insights into building dynamic web applications were valuable, although a few more examples would have been beneficial."
            },
            new TraineeCourse
            {
                TraineeID = 4,
                CourseID = 10,
                EnrolledDate = DateTime.Now,
                Rating = 5,
                ReviewTitle = "Full-Stack Web Development with MERN Stack - Comprehensive Mastery",
                ReviewDate = DateTime.Now,
                Review = "Full-Stack Web Development with MERN Stack was a journey to comprehensive mastery. The curriculum covered both frontend and backend aspects, providing a well-rounded understanding of full-stack development."
            },
            new TraineeCourse
            {
                TraineeID = 4,
                CourseID = 12,
                EnrolledDate = DateTime.Now,
                Rating = 4,
                ReviewTitle = "Interactive UI Design - Engaging Learning Experience",
                ReviewDate = DateTime.Now,
                Review = "Interactive UI Design offered an engaging learning experience in the world of interactive user interface design. The practical exercises enhanced my skills in creating visually appealing digital experiences."
            },
            new TraineeCourse
            {
                TraineeID = 4,
                CourseID = 14,
                EnrolledDate = DateTime.Now,
                Rating = 5,
                ReviewTitle = "Calculus Principles - Mastering Mathematical Analysis",
                ReviewDate = DateTime.Now,
                Review = "Calculus Principles was a journey to mastering mathematical analysis. The course content was clear, and the practical examples provided a deep understanding of fundamental calculus principles."
            },
            new TraineeCourse
            {
                TraineeID = 4,
                CourseID = 16,
                EnrolledDate = DateTime.Now,
                Rating = 4,
                ReviewTitle = "Introduction to Painting - Unleashing Creativity",
                ReviewDate = DateTime.Now,
                Review = "Introduction to Painting was an exploration into unleashing creativity. The course content was enjoyable, and the practical exercises enhanced my painting skills."
            },
            new TraineeCourse
            {
                TraineeID = 4,
                CourseID = 18,
                EnrolledDate = DateTime.Now,
                Rating = 5,
                ReviewTitle = "Physics Essentials - Fascinating Exploration",
                ReviewDate = DateTime.Now,
                Review = "Physics Essentials offered a fascinating exploration into the fundamental principles of physics. The course content was engaging, and the practical examples provided a deep understanding of physics concepts."
            },
            new TraineeCourse
            {
                TraineeID = 4,
                CourseID = 19,
                EnrolledDate = DateTime.Now,
                Rating = 4,
                ReviewTitle = "Chemistry Fundamentals - Building a Strong Foundation",
                ReviewDate = DateTime.Now,
                Review = "Chemistry Fundamentals offered a strong foundation in understanding basic principles and chemical reactions. The course content was well-organized, providing a comprehensive overview of chemistry."
            },
             new TraineeCourse
            {
                TraineeID = 5,
                CourseID = 2,
                EnrolledDate = DateTime.Now,
                Rating = 5,
                ReviewTitle = "Advanced Topics in Technology Innovation - Cutting-Edge Knowledge",
                ReviewDate = DateTime.Now,
                Review = "Advanced Topics in Technology Innovation provided cutting-edge knowledge in artificial intelligence and blockchain. The course content was advanced yet accessible, making it a valuable learning experience."
            },
            new TraineeCourse
            {
                TraineeID = 5,
                CourseID = 4,
                EnrolledDate = DateTime.Now,
                Rating = 4,
                ReviewTitle = "Cloud Computing Essentials - Practical Cloud Skills",
                ReviewDate = DateTime.Now,
                Review = "Cloud Computing Essentials equipped me with practical skills in cloud computing. The hands-on exercises on popular cloud platforms were challenging and beneficial."
            },
            new TraineeCourse
            {
                TraineeID = 5,
                CourseID = 6,
                EnrolledDate = DateTime.Now,
                Rating = 5,
                ReviewTitle = "Web Development Fundamentals - Solid Foundation",
                ReviewDate = DateTime.Now,
                Review = "Web Development Fundamentals provided a solid foundation in web development. The concepts were well-explained, and the hands-on experience enhanced my coding skills."
            },
            new TraineeCourse
            {
                TraineeID = 5,
                CourseID = 8,
                EnrolledDate = DateTime.Now,
                Rating = 4,
                ReviewTitle = "JavaScript and Frontend Frameworks - Interactive Learning",
                ReviewDate = DateTime.Now,
                Review = "JavaScript and Frontend Frameworks offered interactive learning experiences. The practical insights into building dynamic web applications were valuable, although a few more examples would have been beneficial."
            },
            new TraineeCourse
            {
                TraineeID = 5,
                CourseID = 10,
                EnrolledDate = DateTime.Now,
                Rating = 5,
                ReviewTitle = "Full-Stack Web Development with MERN Stack - Comprehensive Mastery",
                ReviewDate = DateTime.Now,
                Review = "Full-Stack Web Development with MERN Stack was a journey to comprehensive mastery. The curriculum covered both frontend and backend aspects, providing a well-rounded understanding of full-stack development."
            },
            new TraineeCourse
            {
                TraineeID = 5,
                CourseID = 12,
                EnrolledDate = DateTime.Now,
                Rating = 4,
                ReviewTitle = "Interactive UI Design - Engaging Learning Experience",
                ReviewDate = DateTime.Now,
                Review = "Interactive UI Design offered an engaging learning experience in the world of interactive user interface design. The practical exercises enhanced my skills in creating visually appealing digital experiences."
            },
            new TraineeCourse
            {
                TraineeID = 5,
                CourseID = 14,
                EnrolledDate = DateTime.Now,
                Rating = 5,
                ReviewTitle = "Calculus Principles - Mastering Mathematical Analysis",
                ReviewDate = DateTime.Now,
                Review = "Calculus Principles was a journey to mastering mathematical analysis. The course content was clear, and the practical examples provided a deep understanding of fundamental calculus principles."
            },
            new TraineeCourse
            {
                TraineeID = 5,
                CourseID = 16,
                EnrolledDate = DateTime.Now,
                Rating = 4,
                ReviewTitle = "Introduction to Painting - Unleashing Creativity",
                ReviewDate = DateTime.Now,
                Review = "Introduction to Painting was an exploration into unleashing creativity. The course content was enjoyable, and the practical exercises enhanced my painting skills."
            },
            new TraineeCourse
            {
                TraineeID = 5,
                CourseID = 18,
                EnrolledDate = DateTime.Now,
                Rating = 5,
                ReviewTitle = "Physics Essentials - Fascinating Exploration",
                ReviewDate = DateTime.Now,
                Review = "Physics Essentials offered a fascinating exploration into the fundamental principles of physics. The course content was engaging, and the practical examples provided a deep understanding of physics concepts."
            },
            new TraineeCourse
            {
                TraineeID = 5,
                CourseID = 19,
                EnrolledDate = DateTime.Now,
                Rating = 4,
                ReviewTitle = "Chemistry Fundamentals - Building a Strong Foundation",
                ReviewDate = DateTime.Now,
                Review = "Chemistry Fundamentals offered a strong foundation in understanding basic principles and chemical reactions. The course content was well-organized, providing a comprehensive overview of chemistry."
            },
             new TraineeCourse
            {
                TraineeID = 6,
                CourseID = 1,
                EnrolledDate = DateTime.Now,
                Rating = 4,
                ReviewTitle = "Solid Introduction to Technology Fundamentals",
                ReviewDate = DateTime.Now,
                Review = "The introduction to technology fundamentals was solid. The course content was well-explained, and the practical examples helped in understanding key concepts."
            },
            new TraineeCourse
            {
                TraineeID = 6,
                CourseID = 5,
                EnrolledDate = DateTime.Now,
                Rating = 5,
                ReviewTitle = "Mastering Emerging Technologies in Cybersecurity",
                ReviewDate = DateTime.Now.AddDays(7),
                Review = "Mastering Emerging Technologies in Cybersecurity was a game-changer. The course covered the latest trends and technologies, providing practical insights into the cybersecurity landscape. The real-world scenarios were particularly beneficial."
            },
            new TraineeCourse
            {
                TraineeID = 6,
                CourseID = 10,
                EnrolledDate = DateTime.Now,
                Rating = 4,
                ReviewTitle = "Full-Stack Web Development with MERN Stack - Comprehensive Learning",
                ReviewDate = DateTime.Now.AddDays(14),
                Review = "Full-Stack Web Development with MERN Stack provided a comprehensive learning experience. The course covered both frontend and backend aspects, enhancing my skills as a full-stack developer. The hands-on projects were challenging and rewarding."
            },
            new TraineeCourse
            {
                TraineeID = 6,
                CourseID = 15,
                EnrolledDate = DateTime.Now,
                Rating = 5,
                ReviewTitle = "Algebra Basics - Building a Strong Foundation",
                ReviewDate = DateTime.Now.AddDays(21),
                Review = "Algebra Basics provided a strong foundation in algebraic concepts. The course content was clear, and the practical exercises enhanced my understanding of fundamental algebra. The instructor's explanations were particularly helpful."
            },
            new TraineeCourse
            {
                TraineeID = 6,
                CourseID = 3,
                EnrolledDate = DateTime.Now,
                Rating = 4,
                ReviewTitle = "DevOps Foundations - Collaborative Excellence",
                ReviewDate = DateTime.Now.AddDays(28),
                Review = "DevOps Foundations is a masterpiece in collaborative excellence. The course provided practical insights into collaboration between development and operations teams. The real-world scenarios were eye-opening and prepared me for real-world challenges."
            },
            new TraineeCourse
            {
                TraineeID = 6,
                CourseID = 8,
                EnrolledDate = DateTime.Now,
                Rating = 5,
                ReviewTitle = "JavaScript and Frontend Frameworks - Interactive Learning",
                ReviewDate = DateTime.Now.AddDays(35),
                Review = "JavaScript and Frontend Frameworks offered interactive learning experiences. The course content was engaging, and the practical exercises helped me understand the power of JavaScript in building dynamic web applications. The instructor's approach was fantastic."
            },
            new TraineeCourse
            {
                TraineeID = 6,
                CourseID = 12,
                EnrolledDate = DateTime.Now,
                Rating = 4,
                ReviewTitle = "Interactive UI Design - Crafting Digital Experiences",
                ReviewDate = DateTime.Now.AddDays(42),
                Review = "Diving into the world of interactive UI design was an enlightening experience. The course provided valuable insights into crafting engaging digital experiences. The hands-on projects allowed me to apply theoretical knowledge to practical scenarios."
            },
            new TraineeCourse
            {
                TraineeID = 6,
                CourseID = 19,
                EnrolledDate = DateTime.Now,
                Rating = 5,
                ReviewTitle = "Chemistry Fundamentals - A Comprehensive Overview",
                ReviewDate = DateTime.Now.AddDays(49),
                Review = "Exploring the basic principles of chemistry and chemical reactions was comprehensive. The course content was well-organized, and the practical applications enhanced my understanding of chemistry fundamentals. The experiments were particularly enjoyable."
            },
            new TraineeCourse
            {
                TraineeID = 6,
                CourseID = 7,
                EnrolledDate = DateTime.Now,
                Rating = 4,
                ReviewTitle = "Responsive Web Design and CSS Frameworks - Visual Appeal",
                ReviewDate = DateTime.Now.AddDays(56),
                Review = "Learning to create responsive and visually appealing web pages using CSS frameworks was an enriching experience. The practical insights into modern web design practices were valuable. I appreciated the emphasis on visual appeal and user experience."
            },
            new TraineeCourse
            {
                TraineeID = 6,
                CourseID = 14,
                EnrolledDate = DateTime.Now,
                Rating = 5,
                ReviewTitle = "Mastering Calculus Principles",
                ReviewDate = DateTime.Now.AddDays(63),
                Review = "Diving into the fundamental principles of calculus was a challenging yet rewarding journey. The course provided a solid foundation, and the examples helped in mastering calculus principles. The mathematical rigor was particularly commendable."
            },
             new TraineeCourse
            {
                TraineeID = 7,
                CourseID = 2,
                EnrolledDate = DateTime.Now,
                Rating = 5,
                ReviewTitle = "Advanced Topics in Technology Innovation - Mind-Expanding",
                ReviewDate = DateTime.Now,
                Review = "Diving into advanced topics like artificial intelligence and blockchain was truly mind-expanding. The course provided a unique perspective, and the real-world applications were insightful. The practical projects were particularly challenging and rewarding."
            },
            new TraineeCourse
            {
                TraineeID = 7,
                CourseID = 6,
                EnrolledDate = DateTime.Now,
                Rating = 4,
                ReviewTitle = "Web Development Fundamentals - Building a Strong Foundation",
                ReviewDate = DateTime.Now.AddDays(-7),
                Review = "Web Development Fundamentals laid a strong foundation for my journey in web development. The concepts were explained clearly, and the hands-on exercises enhanced my coding skills. The instructor's guidance was invaluable."
            },
            new TraineeCourse
            {
                TraineeID = 7,
                CourseID = 11,
                EnrolledDate = DateTime.Now,
                Rating = 5,
                ReviewTitle = "UX/UI Fundamentals - Understanding User Experience",
                ReviewDate = DateTime.Now.AddDays(-14),
                Review = "Exploring the foundational principles of UX/UI design was fantastic. The course content was well-structured, and the practical exercises provided a solid understanding of user experience principles. The design critiques were particularly insightful."
            },
            new TraineeCourse
            {
                TraineeID = 7,
                CourseID = 16,
                EnrolledDate = DateTime.Now,
                Rating = 4,
                ReviewTitle = "Introduction to Painting - Unleashing Creativity",
                ReviewDate = DateTime.Now.AddDays(-21),
                Review = "Exploring the world of visual arts and developing painting skills was an enriching experience. The course content was engaging, and the practical exercises enhanced my creativity. The exploration of different painting styles was particularly enjoyable."
            },
            new TraineeCourse
            {
                TraineeID = 7,
                CourseID = 3,
                EnrolledDate = DateTime.Now,
                Rating = 5,
                ReviewTitle = "DevOps Foundations - A Collaboration Masterpiece",
                ReviewDate = DateTime.Now.AddDays(-28),
                Review = "DevOps Foundations is a collaboration masterpiece. It provided practical insights into collaboration between development and operations teams. The real-world scenarios were eye-opening and prepared me for real-world challenges."
            },
            new TraineeCourse
            {
                TraineeID = 7,
                CourseID = 12,
                EnrolledDate = DateTime.Now,
                Rating = 4,
                ReviewTitle = "Interactive UI Design - Crafting Engaging Digital Experiences",
                ReviewDate = DateTime.Now.AddDays(-35),
                Review = "Diving into the world of interactive UI design was an enlightening experience. The course provided valuable insights into crafting engaging digital experiences. The hands-on projects allowed me to apply theoretical knowledge to practical scenarios."
            },
            new TraineeCourse
            {
                TraineeID = 7,
                CourseID = 17,
                EnrolledDate = DateTime.Now,
                Rating = 5,
                ReviewTitle = "Biology Fundamentals - A Fascinating Journey",
                ReviewDate = DateTime.Now.AddDays(-42),
                Review = "Gaining a comprehensive understanding of fundamental biological concepts was fascinating. The course content was well-structured, and the practical applications enhanced my knowledge of biology fundamentals. The exploration of different biological systems was particularly insightful."
            },
            new TraineeCourse
            {
                TraineeID = 7,
                CourseID = 8,
                EnrolledDate = DateTime.Now,
                Rating = 4,
                ReviewTitle = "JavaScript and Frontend Frameworks - Unleashing Interactivity",
                ReviewDate = DateTime.Now.AddDays(-49),
                Review = "JavaScript and Frontend Frameworks offered interactive learning experiences. The course content was engaging, and the practical exercises helped me understand the power of JavaScript in building dynamic web applications. The instructor's approach was fantastic."
            },
            new TraineeCourse
            {
                TraineeID = 7,
                CourseID = 13,
                EnrolledDate = DateTime.Now,
                Rating = 5,
                ReviewTitle = "Statistics Fundamentals - A Statistical Journey",
                ReviewDate = DateTime.Now.AddDays(-56),
                Review = "Gaining a comprehensive understanding of statistics was a statistical journey. The course covered foundational principles with clarity, and the practical applications enhanced my statistical skills. The real-world examples were particularly beneficial."
            },
            new TraineeCourse
            {
                TraineeID = 7,
                CourseID = 18,
                EnrolledDate = DateTime.Now,
                Rating = 4,
                ReviewTitle = "Physics Essentials - Exploring the Fundamentals",
                ReviewDate = DateTime.Now.AddDays(-63),
                Review = "Exploring the fundamental principles of physics and their applications was fascinating. The course content was clear, and the practical examples provided a deep understanding of physics fundamentals. The experiments were particularly enjoyable."
            },
             new TraineeCourse
            {
                TraineeID = 8,
                CourseID = 4,
                EnrolledDate = DateTime.Now,
                Rating = 5,
                ReviewTitle = "Cloud Computing Essentials - Mastering the Cloud",
                ReviewDate = DateTime.Now.AddDays(63),
                Review = "Exploring the fundamentals of cloud computing was a masterclass. The course covered practical skills in using popular cloud platforms, providing a solid foundation for real-world applications. The real-world scenarios were particularly insightful."
            },
            new TraineeCourse
            {
                TraineeID = 8,
                CourseID = 9,
                EnrolledDate = DateTime.Now,
                Rating = 4,
                ReviewTitle = "Backend Development with Node.js and Express - Powerful Server-Side Applications",
                ReviewDate = DateTime.Now.AddDays(56),
                Review = "Building powerful server-side applications using Node.js and the Express framework was empowering. The hands-on practice provided valuable insights into developing scalable and efficient backend solutions. The real-world projects were particularly challenging and rewarding."
            },
            new TraineeCourse
            {
                TraineeID = 8,
                CourseID = 14,
                EnrolledDate = DateTime.Now,
                Rating = 5,
                ReviewTitle = "Mastering Calculus Principles",
                ReviewDate = DateTime.Now.AddDays(49),
                Review = "Diving into the fundamental principles of calculus was a challenging yet rewarding journey. The course provided a solid foundation, and the examples helped in mastering calculus principles. The mathematical rigor was particularly commendable."
            },
            new TraineeCourse
            {
                TraineeID = 8,
                CourseID = 1,
                EnrolledDate = DateTime.Now,
                Rating = 4,
                ReviewTitle = "Introduction to Technology Fundamentals - A Technological Primer",
                ReviewDate = DateTime.Now.AddDays(42),
                Review = "The introduction to technology fundamentals served as a comprehensive technological primer. The course content was well-structured, and the practical examples enhanced my understanding of basic technological principles. The hands-on labs were particularly beneficial."
            },
            new TraineeCourse
            {
                TraineeID = 8,
                CourseID = 7,
                EnrolledDate = DateTime.Now,
                Rating = 5,
                ReviewTitle = "Responsive Web Design and CSS Frameworks - Crafting Visually Appealing Websites",
                ReviewDate = DateTime.Now.AddDays(35),
                Review = "Learning to create responsive and visually appealing web pages using CSS frameworks was an enriching experience. The practical insights into modern web design practices were valuable. I appreciated the emphasis on visual appeal and user experience."
            },
            new TraineeCourse
            {
                TraineeID = 8,
                CourseID = 16,
                EnrolledDate = DateTime.Now,
                Rating = 4,
                ReviewTitle = "Introduction to Painting - Unleashing Creativity",
                ReviewDate = DateTime.Now.AddDays(28),
                Review = "Exploring the world of visual arts and developing painting skills was an enriching experience. The course content was engaging, and the practical exercises enhanced my creativity. The exploration of different painting styles was particularly enjoyable."
            },
            new TraineeCourse
            {
                TraineeID = 8,
                CourseID = 12,
                EnrolledDate = DateTime.Now,
                Rating = 5,
                ReviewTitle = "Interactive UI Design - Crafting Digital Experiences",
                ReviewDate = DateTime.Now.AddDays(21),
                Review = "Diving into the world of interactive UI design was an enlightening experience. The course provided valuable insights into crafting engaging digital experiences. The hands-on projects allowed me to apply theoretical knowledge to practical scenarios."
            },
            new TraineeCourse
            {
                TraineeID = 8,
                CourseID = 3,
                EnrolledDate = DateTime.Now,
                Rating = 4,
                ReviewTitle = "DevOps Foundations - A Collaboration Masterpiece",
                ReviewDate = DateTime.Now.AddDays(14),
                Review = "DevOps Foundations is a collaboration masterpiece. It provided practical insights into collaboration between development and operations teams. The real-world scenarios were eye-opening and prepared me for real-world challenges."
            },
            new TraineeCourse
            {
                TraineeID = 8,
                CourseID = 18,
                EnrolledDate = DateTime.Now,
                Rating = 5,
                ReviewTitle = "Physics Essentials - Exploring the Fundamentals",
                ReviewDate = DateTime.Now.AddDays(7),
                Review = "Exploring the fundamental principles of physics and their applications was fascinating. The course content was clear, and the practical examples provided a deep understanding of physics fundamentals. The experiments were particularly enjoyable."
            },
              new TraineeCourse
            {
                TraineeID = 9,
                CourseID = 14,
                EnrolledDate = DateTime.Now,
                Rating = 5,
                ReviewTitle = "Calculus Principles - A Mathematical Journey",
                ReviewDate = DateTime.Now.AddDays(63),
                Review = "Diving into the fundamental principles of calculus was a mathematical journey. The course provided a solid foundation, and the examples helped in mastering calculus principles. The mathematical rigor was particularly commendable."
            },
            new TraineeCourse
            {
                TraineeID = 9,
                CourseID = 3,
                EnrolledDate = DateTime.Now,
                Rating = 4,
                ReviewTitle = "DevOps Foundations - A Collaboration Masterpiece",
                ReviewDate = DateTime.Now.AddDays(56),
                Review = "DevOps Foundations is a collaboration masterpiece. It provided practical insights into collaboration between development and operations teams. The real-world scenarios were eye-opening and prepared me for real-world challenges."
            },
            new TraineeCourse
            {
                TraineeID = 9,
                CourseID = 11,
                EnrolledDate = DateTime.Now,
                Rating = 5,
                ReviewTitle = "UX/UI Fundamentals - Understanding User Experience",
                ReviewDate = DateTime.Now.AddDays(49),
                Review = "Exploring the foundational principles of UX/UI design was fantastic. The course content was well-structured, and the practical exercises provided a solid understanding of user experience principles. The design critiques were particularly insightful."
            },
            new TraineeCourse
            {
                TraineeID = 9,
                CourseID = 16,
                EnrolledDate = DateTime.Now,
                Rating = 4,
                ReviewTitle = "Introduction to Painting - Unleashing Creativity",
                ReviewDate = DateTime.Now.AddDays(42),
                Review = "Exploring the world of visual arts and developing painting skills was an enriching experience. The course content was engaging, and the practical exercises enhanced my creativity. The exploration of different painting styles was particularly enjoyable."
            },
            new TraineeCourse
            {
                TraineeID = 9,
                CourseID = 8,
                EnrolledDate = DateTime.Now,
                Rating = 5,
                ReviewTitle = "JavaScript and Frontend Frameworks - Unleashing Interactivity",
                ReviewDate = DateTime.Now.AddDays(35),
                Review = "JavaScript and Frontend Frameworks offered interactive learning experiences. The course content was engaging, and the practical exercises helped me understand the power of JavaScript in building dynamic web applications. The instructor's approach was fantastic."
            },
            new TraineeCourse
            {
                TraineeID = 9,
                CourseID = 13,
                EnrolledDate = DateTime.Now,
                Rating = 4,
                ReviewTitle = "Statistics Fundamentals - A Statistical Journey",
                ReviewDate = DateTime.Now.AddDays(28),
                Review = "Gaining a comprehensive understanding of statistics was a statistical journey. The course covered foundational principles with clarity, and the practical applications enhanced my statistical skills. The real-world examples were particularly beneficial."
            },
            new TraineeCourse
            {
                TraineeID = 9,
                CourseID = 18,
                EnrolledDate = DateTime.Now,
                Rating = 5,
                ReviewTitle = "Physics Essentials - Exploring the Fundamentals",
                ReviewDate = DateTime.Now.AddDays(21),
                Review = "Exploring the fundamental principles of physics and their applications was fascinating. The course content was clear, and the practical examples provided a deep understanding of physics fundamentals. The experiments were particularly enjoyable."
            },
            new TraineeCourse
            {
                TraineeID = 9,
                CourseID = 12,
                EnrolledDate = DateTime.Now,
                Rating = 4,
                ReviewTitle = "Interactive UI Design - Crafting Engaging Digital Experiences",
                ReviewDate = DateTime.Now.AddDays(14),
                Review = "Diving into the world of interactive UI design was an enlightening experience. The course provided valuable insights into crafting engaging digital experiences. The hands-on projects allowed me to apply theoretical knowledge to practical scenarios."
            },
            new TraineeCourse
            {
                TraineeID = 9,
                CourseID = 5,
                EnrolledDate = DateTime.Now,
                Rating = 5,
                ReviewTitle = "Emerging Technologies in Cybersecurity - Staying Ahead of Threats",
                ReviewDate = DateTime.Now.AddDays(7),
                Review = "Staying ahead of cyber threats by exploring the latest trends and technologies in cybersecurity was crucial. The course content was relevant, and the hands-on labs provided practical skills in dealing with cybersecurity challenges. The real-world scenarios were particularly insightful."
            },
            new TraineeCourse
            {
                TraineeID = 9,
                CourseID = 10,
                EnrolledDate = DateTime.Now,
                Rating = 4,
                ReviewTitle = "Full-Stack Web Development with MERN Stack - Mastering the Stack",
                ReviewDate = DateTime.Now,
                Review = "Becoming a full-stack developer using the MERN (MongoDB, Express.js, React.js, Node.js) stack was a challenging yet rewarding journey. The course covered the entire stack comprehensively, and the hands-on projects provided practical insights. The real-world applications were particularly beneficial."
            },
            new TraineeCourse
            {
                TraineeID = 10,
                CourseID = 6,
                EnrolledDate = DateTime.Now,
                Rating = 4,
                ReviewTitle = "Web Development Fundamentals - Building a Strong Foundation",
                ReviewDate = DateTime.Now.AddDays(63),
                Review = "Web Development Fundamentals laid a strong foundation for my journey in web development. The concepts were explained clearly, and the hands-on exercises enhanced my coding skills. The instructor's guidance was invaluable."
            },
            new TraineeCourse
            {
                TraineeID = 10,
                CourseID = 11,
                EnrolledDate = DateTime.Now,
                Rating = 5,
                ReviewTitle = "UX/UI Fundamentals - Understanding User Experience",
                ReviewDate = DateTime.Now.AddDays(56),
                Review = "Exploring the foundational principles of UX/UI design was fantastic. The course content was well-structured, and the practical exercises provided a solid understanding of user experience principles. The design critiques were particularly insightful."
            },
            new TraineeCourse
            {
                TraineeID = 10,
                CourseID = 1,
                EnrolledDate = DateTime.Now,
                Rating = 4,
                ReviewTitle = "Introduction to Technology Fundamentals - A Technological Primer",
                ReviewDate = DateTime.Now.AddDays(49),
                Review = "The introduction to technology fundamentals served as a comprehensive technological primer. The course content was well-structured, and the practical examples enhanced my understanding of basic technological principles. The hands-on labs were particularly beneficial."
            },
            new TraineeCourse
            {
                TraineeID = 10,
                CourseID = 17,
                EnrolledDate = DateTime.Now,
                Rating = 5,
                ReviewTitle = "Biology Fundamentals - A Fascinating Journey",
                ReviewDate = DateTime.Now.AddDays(42),
                Review = "Gaining a comprehensive understanding of fundamental biological concepts was fascinating. The course content was well-structured, and the practical applications enhanced my knowledge of biology fundamentals. The exploration of different biological systems was particularly insightful."
            },
            new TraineeCourse
            {
                TraineeID = 10,
                CourseID = 8,
                EnrolledDate = DateTime.Now,
                Rating = 4,
                ReviewTitle = "JavaScript and Frontend Frameworks - Unleashing Interactivity",
                ReviewDate = DateTime.Now.AddDays(35),
                Review = "JavaScript and Frontend Frameworks offered interactive learning experiences. The course content was engaging, and the practical exercises helped me understand the power of JavaScript in building dynamic web applications. The instructor's approach was fantastic."
            },
            new TraineeCourse
            {
                TraineeID = 10,
                CourseID = 13,
                EnrolledDate = DateTime.Now,
                Rating = 5,
                ReviewTitle = "Statistics Fundamentals - A Statistical Journey",
                ReviewDate = DateTime.Now.AddDays(28),
                Review = "Gaining a comprehensive understanding of statistics was a statistical journey. The course covered foundational principles with clarity, and the practical applications enhanced my statistical skills. The real-world examples were particularly beneficial."
            },
            new TraineeCourse
            {
                TraineeID = 10,
                CourseID = 18,
                EnrolledDate = DateTime.Now,
                Rating = 4,
                ReviewTitle = "Physics Essentials - Exploring the Fundamentals",
                ReviewDate = DateTime.Now.AddDays(21),
                Review = "Exploring the fundamental principles of physics and their applications was fascinating. The course content was clear, and the practical examples provided a deep understanding of physics fundamentals. The experiments were particularly enjoyable."
            },
            new TraineeCourse
            {
                TraineeID = 10,
                CourseID = 12,
                EnrolledDate = DateTime.Now,
                Rating = 5,
                ReviewTitle = "Interactive UI Design - Crafting Digital Experiences",
                ReviewDate = DateTime.Now.AddDays(14),
                Review = "Diving into the world of interactive UI design was an enlightening experience. The course provided valuable insights into crafting engaging digital experiences. The hands-on projects allowed me to apply theoretical knowledge to practical scenarios."
            },
            new TraineeCourse
            {
                TraineeID = 10,
                CourseID = 5,
                EnrolledDate = DateTime.Now,
                Rating = 4,
                ReviewTitle = "Emerging Technologies in Cybersecurity - Staying Ahead of Threats",
                ReviewDate = DateTime.Now.AddDays(7),
                Review = "Staying ahead of cyber threats by exploring the latest trends and technologies in cybersecurity was crucial. The course content was relevant, and the hands-on labs provided practical skills in dealing with cybersecurity challenges. The real-world scenarios were particularly insightful."
            },
            new TraineeCourse
            {
                TraineeID = 10,
                CourseID = 10,
                EnrolledDate = DateTime.Now,
                Rating = 5,
                ReviewTitle = "Full-Stack Web Development with MERN Stack - Mastering the Stack",
                ReviewDate = DateTime.Now,
                Review = "Becoming a full-stack developer using the MERN (MongoDB, Express.js, React.js, Node.js) stack was a challenging yet rewarding journey. The course covered the entire stack comprehensively, and the hands-on projects provided practical insights. The real-world applications were particularly beneficial."
            },
             new TraineeCourse
            {
                TraineeID = 11,
                CourseID = 2,
                EnrolledDate = DateTime.Now,
                Rating = 4,
                ReviewTitle = "Advanced Topics in Technology Innovation - Exploring Cutting-Edge Concepts",
                ReviewDate = DateTime.Now.AddDays(63),
                Review = "Diving deep into advanced topics such as artificial intelligence, blockchain, and the Internet of Things was intellectually stimulating. The course content was comprehensive, and the real-world applications provided insights into the latest technological innovations. The hands-on projects were particularly challenging and rewarding."
            },
            new TraineeCourse
            {
                TraineeID = 11,
                CourseID = 15,
                EnrolledDate = DateTime.Now,
                Rating = 5,
                ReviewTitle = "Algebra Basics - Building a Solid Mathematical Foundation",
                ReviewDate = DateTime.Now.AddDays(56),
                Review = "Building a solid foundation in algebraic concepts and problem-solving was fundamental. The course content was well-organized, and the practical exercises enhanced my understanding of algebra basics. The mathematical applications were particularly insightful."
            },
            new TraineeCourse
            {
                TraineeID = 11,
                CourseID = 6,
                EnrolledDate = DateTime.Now,
                Rating = 4,
                ReviewTitle = "Web Development Fundamentals - Building a Strong Foundation",
                ReviewDate = DateTime.Now.AddDays(49),
                Review = "Web Development Fundamentals laid a strong foundation for my journey in web development. The concepts were explained clearly, and the hands-on exercises enhanced my coding skills. The instructor's guidance was invaluable."
            },
            new TraineeCourse
            {
                TraineeID = 11,
                CourseID = 12,
                EnrolledDate = DateTime.Now,
                Rating = 5,
                ReviewTitle = "Interactive UI Design - Crafting Digital Experiences",
                ReviewDate = DateTime.Now.AddDays(42),
                Review = "Diving into the world of interactive UI design was an enlightening experience. The course provided valuable insights into crafting engaging digital experiences. The hands-on projects allowed me to apply theoretical knowledge to practical scenarios."
            },
            new TraineeCourse
            {
                TraineeID = 11,
                CourseID = 8,
                EnrolledDate = DateTime.Now,
                Rating = 4,
                ReviewTitle = "JavaScript and Frontend Frameworks - Unleashing Interactivity",
                ReviewDate = DateTime.Now.AddDays(35),
                Review = "JavaScript and Frontend Frameworks offered interactive learning experiences. The course content was engaging, and the practical exercises helped me understand the power of JavaScript in building dynamic web applications. The instructor's approach was fantastic."
            },
            new TraineeCourse
            {
                TraineeID = 11,
                CourseID = 13,
                EnrolledDate = DateTime.Now,
                Rating = 5,
                ReviewTitle = "Statistics Fundamentals - A Statistical Journey",
                ReviewDate = DateTime.Now.AddDays(28),
                Review = "Gaining a comprehensive understanding of statistics was a statistical journey. The course covered foundational principles with clarity, and the practical applications enhanced my statistical skills. The real-world examples were particularly beneficial."
            },
            new TraineeCourse
            {
                TraineeID = 11,
                CourseID = 18,
                EnrolledDate = DateTime.Now,
                Rating = 4,
                ReviewTitle = "Physics Essentials - Exploring the Fundamentals",
                ReviewDate = DateTime.Now.AddDays(21),
                Review = "Exploring the fundamental principles of physics and their applications was fascinating. The course content was clear, and the practical examples provided a deep understanding of physics fundamentals. The experiments were particularly enjoyable."
            },
            new TraineeCourse
            {
                TraineeID = 11,
                CourseID = 4,
                EnrolledDate = DateTime.Now,
                Rating = 5,
                ReviewTitle = "Cloud Computing Essentials - Mastering the Cloud",
                ReviewDate = DateTime.Now.AddDays(14),
                Review = "Exploring the fundamentals of cloud computing was a masterclass. The course covered practical skills in using popular cloud platforms, providing a solid foundation for real-world applications. The real-world scenarios were particularly insightful."
            },
            new TraineeCourse
            {
                TraineeID = 11,
                CourseID = 17,
                EnrolledDate = DateTime.Now,
                Rating = 4,
                ReviewTitle = "Biology Fundamentals - A Fascinating Journey",
                ReviewDate = DateTime.Now.AddDays(7),
                Review = "Gaining a comprehensive understanding of fundamental biological concepts was fascinating. The course content was well-structured, and the practical applications enhanced my knowledge of biology fundamentals. The exploration of different biological systems was particularly insightful."
            },
            new TraineeCourse
            {
                TraineeID = 11,
                CourseID = 10,
                EnrolledDate = DateTime.Now,
                Rating = 5,
                ReviewTitle = "Full-Stack Web Development with MERN Stack - Mastering the Stack",
                ReviewDate = DateTime.Now,
                Review = "Becoming a full-stack developer using the MERN (MongoDB, Express.js, React.js, Node.js) stack was a challenging yet rewarding journey. The course covered the entire stack comprehensively, and the hands-on projects provided practical insights. The real-world applications were particularly beneficial."
            },
             new TraineeCourse
            {
                TraineeID = 12,
                CourseID = 7,
                EnrolledDate = DateTime.Now,
                Rating = 4,
                ReviewTitle = "Responsive Web Design and CSS Frameworks - Crafting Visually Appealing Websites",
                ReviewDate = DateTime.Now.AddDays(63),
                Review = "Learning to create responsive and visually appealing web pages using CSS frameworks was an enriching experience. The practical insights into modern web design practices were valuable. I appreciated the emphasis on visual appeal and user experience."
            },
            new TraineeCourse
            {
                TraineeID = 12,
                CourseID = 3,
                EnrolledDate = DateTime.Now,
                Rating = 5,
                ReviewTitle = "DevOps Foundations - A Collaboration Masterpiece",
                ReviewDate = DateTime.Now.AddDays(56),
                Review = "DevOps Foundations is a collaboration masterpiece. It provided practical insights into collaboration between development and operations teams. The real-world scenarios were eye-opening and prepared me for real-world challenges."
            },
            new TraineeCourse
            {
                TraineeID = 12,
                CourseID = 11,
                EnrolledDate = DateTime.Now,
                Rating = 4,
                ReviewTitle = "UX/UI Fundamentals - Understanding User Experience",
                ReviewDate = DateTime.Now.AddDays(49),
                Review = "Exploring the foundational principles of UX/UI design was fantastic. The course content was well-structured, and the practical exercises provided a solid understanding of user experience principles. The design critiques were particularly insightful."
            },
            new TraineeCourse
            {
                TraineeID = 12,
                CourseID = 1,
                EnrolledDate = DateTime.Now,
                Rating = 5,
                ReviewTitle = "Introduction to Technology Fundamentals - A Technological Primer",
                ReviewDate = DateTime.Now.AddDays(42),
                Review = "The introduction to technology fundamentals served as a comprehensive technological primer. The course content was well-structured, and the practical examples enhanced my understanding of basic technological principles. The hands-on labs were particularly beneficial."
            },
            new TraineeCourse
            {
                TraineeID = 12,
                CourseID = 17,
                EnrolledDate = DateTime.Now,
                Rating = 4,
                ReviewTitle = "Biology Fundamentals - A Fascinating Journey",
                ReviewDate = DateTime.Now.AddDays(35),
                Review = "Gaining a comprehensive understanding of fundamental biological concepts was fascinating. The course content was well-structured, and the practical applications enhanced my knowledge of biology fundamentals. The exploration of different biological systems was particularly insightful."
            },
            new TraineeCourse
            {
                TraineeID = 12,
                CourseID = 6,
                EnrolledDate = DateTime.Now,
                Rating = 5,
                ReviewTitle = "Web Development Fundamentals - Building a Strong Foundation",
                ReviewDate = DateTime.Now.AddDays(28),
                Review = "Web Development Fundamentals laid a strong foundation for my journey in web development. The concepts were explained clearly, and the hands-on exercises enhanced my coding skills. The instructor's guidance was invaluable."
            },
            new TraineeCourse
            {
                TraineeID = 12,
                CourseID = 13,
                EnrolledDate = DateTime.Now,
                Rating = 4,
                ReviewTitle = "Statistics Fundamentals - A Statistical Journey",
                ReviewDate = DateTime.Now.AddDays(21),
                Review = "Gaining a comprehensive understanding of statistics was a statistical journey. The course covered foundational principles with clarity, and the practical applications enhanced my statistical skills. The real-world examples were particularly beneficial."
            },
            new TraineeCourse
            {
                TraineeID = 12,
                CourseID = 18,
                EnrolledDate = DateTime.Now,
                Rating = 5,
                ReviewTitle = "Physics Essentials - Exploring the Fundamentals",
                ReviewDate = DateTime.Now.AddDays(14),
                Review = "Exploring the fundamental principles of physics and their applications was fascinating. The course content was clear, and the practical examples provided a deep understanding of physics fundamentals. The experiments were particularly enjoyable."
            },
            new TraineeCourse
            {
                TraineeID = 12,
                CourseID = 12,
                EnrolledDate = DateTime.Now,
                Rating = 4,
                ReviewTitle = "Interactive UI Design - Crafting Digital Experiences",
                ReviewDate = DateTime.Now.AddDays(7),
                Review = "Diving into the world of interactive UI design was an enlightening experience. The course provided valuable insights into crafting engaging digital experiences. The hands-on projects allowed me to apply theoretical knowledge to practical scenarios."
            },
            new TraineeCourse
            {
                TraineeID = 12,
                CourseID = 5,
                EnrolledDate = DateTime.Now,
                Rating = 5,
                ReviewTitle = "Emerging Technologies in Cybersecurity - Staying Ahead of Threats",
                ReviewDate = DateTime.Now,
                Review = "Staying ahead of cyber threats by exploring the latest trends and technologies in cybersecurity was crucial. The course content was relevant, and the hands-on labs provided practical skills in dealing with cybersecurity challenges. The real-world scenarios were particularly insightful."
            },
             new TraineeCourse
            {
                TraineeID = 13,
                CourseID = 10,
                EnrolledDate = DateTime.Now,
                Rating = 4,
                ReviewTitle = "Full-Stack Web Development with MERN Stack - Mastering the Stack",
                ReviewDate = DateTime.Now.AddDays(63),
                Review = "Becoming a full-stack developer using the MERN (MongoDB, Express.js, React.js, Node.js) stack was a challenging yet rewarding journey. The course covered the entire stack comprehensively, and the hands-on projects provided practical insights. The real-world applications were particularly beneficial."
            },
            new TraineeCourse
            {
                TraineeID = 13,
                CourseID = 11,
                EnrolledDate = DateTime.Now,
                Rating = 5,
                ReviewTitle = "UX/UI Fundamentals - Understanding User Experience",
                ReviewDate = DateTime.Now.AddDays(56),
                Review = "Exploring the foundational principles of UX/UI design was fantastic. The course content was well-structured, and the practical exercises provided a solid understanding of user experience principles. The design critiques were particularly insightful."
            },
            new TraineeCourse
            {
                TraineeID = 13,
                CourseID = 6,
                EnrolledDate = DateTime.Now,
                Rating = 4,
                ReviewTitle = "Web Development Fundamentals - Building a Strong Foundation",
                ReviewDate = DateTime.Now.AddDays(49),
                Review = "Web Development Fundamentals laid a strong foundation for my journey in web development. The concepts were explained clearly, and the hands-on exercises enhanced my coding skills. The instructor's guidance was invaluable."
            },
            new TraineeCourse
            {
                TraineeID = 13,
                CourseID = 12,
                EnrolledDate = DateTime.Now,
                Rating = 5,
                ReviewTitle = "Interactive UI Design - Crafting Digital Experiences",
                ReviewDate = DateTime.Now.AddDays(42),
                Review = "Diving into the world of interactive UI design was an enlightening experience. The course provided valuable insights into crafting engaging digital experiences. The hands-on projects allowed me to apply theoretical knowledge to practical scenarios."
            },
            new TraineeCourse
            {
                TraineeID = 13,
                CourseID = 8,
                EnrolledDate = DateTime.Now,
                Rating = 4,
                ReviewTitle = "JavaScript and Frontend Frameworks - Unleashing Interactivity",
                ReviewDate = DateTime.Now.AddDays(35),
                Review = "JavaScript and Frontend Frameworks offered interactive learning experiences. The course content was engaging, and the practical exercises helped me understand the power of JavaScript in building dynamic web applications. The instructor's approach was fantastic."
            },
            new TraineeCourse
            {
                TraineeID = 13,
                CourseID = 13,
                EnrolledDate = DateTime.Now,
                Rating = 5,
                ReviewTitle = "Statistics Fundamentals - A Statistical Journey",
                ReviewDate = DateTime.Now.AddDays(28),
                Review = "Gaining a comprehensive understanding of statistics was a statistical journey. The course covered foundational principles with clarity, and the practical applications enhanced my statistical skills. The real-world examples were particularly beneficial."
            },
            new TraineeCourse
            {
                TraineeID = 13,
                CourseID = 18,
                EnrolledDate = DateTime.Now,
                Rating = 4,
                ReviewTitle = "Physics Essentials - Exploring the Fundamentals",
                ReviewDate = DateTime.Now.AddDays(21),
                Review = "Exploring the fundamental principles of physics and their applications was fascinating. The course content was clear, and the practical examples provided a deep understanding of physics fundamentals. The experiments were particularly enjoyable."
            },
            new TraineeCourse
            {
                TraineeID = 13,
                CourseID = 4,
                EnrolledDate = DateTime.Now,
                Rating = 5,
                ReviewTitle = "Cloud Computing Essentials - Mastering the Cloud",
                ReviewDate = DateTime.Now.AddDays(14),
                Review = "Exploring the fundamentals of cloud computing was a masterclass. The course covered practical skills in using popular cloud platforms, providing a solid foundation for real-world applications. The real-world scenarios were particularly insightful."
            },
            new TraineeCourse
            {
                TraineeID = 13,
                CourseID = 17,
                EnrolledDate = DateTime.Now,
                Rating = 4,
                ReviewTitle = "Biology Fundamentals - A Fascinating Journey",
                ReviewDate = DateTime.Now.AddDays(7),
                Review = "Gaining a comprehensive understanding of fundamental biological concepts was fascinating. The course content was well-structured, and the practical applications enhanced my knowledge of biology fundamentals. The exploration of different biological systems was particularly insightful."
            },
            
            new TraineeCourse
            {
                TraineeID = 14,
                CourseID = 1,
                EnrolledDate = DateTime.Now,
                Rating = 4,
                ReviewTitle = "Introduction to Technology Fundamentals - A Technological Primer",
                ReviewDate = DateTime.Now.AddDays(63),
                Review = "The introduction to technology fundamentals served as a comprehensive technological primer. The course content was well-structured, and the practical examples enhanced my understanding of basic technological principles. The hands-on labs were particularly beneficial."
            },
            new TraineeCourse
            {
                TraineeID = 14,
                CourseID = 17,
                EnrolledDate = DateTime.Now,
                Rating = 5,
                ReviewTitle = "Biology Fundamentals - A Fascinating Journey",
                ReviewDate = DateTime.Now.AddDays(56),
                Review = "Gaining a comprehensive understanding of fundamental biological concepts was fascinating. The course content was well-structured, and the practical applications enhanced my knowledge of biology fundamentals. The exploration of different biological systems was particularly insightful."
            },
            new TraineeCourse
            {
                TraineeID = 14,
                CourseID = 6,
                EnrolledDate = DateTime.Now,
                Rating = 4,
                ReviewTitle = "Web Development Fundamentals - Building a Strong Foundation",
                ReviewDate = DateTime.Now.AddDays(49),
                Review = "Web Development Fundamentals laid a strong foundation for my journey in web development. The concepts were explained clearly, and the hands-on exercises enhanced my coding skills. The instructor's guidance was invaluable."
            },
            new TraineeCourse
            {
                TraineeID = 14,
                CourseID = 12,
                EnrolledDate = DateTime.Now,
                Rating = 5,
                ReviewTitle = "Interactive UI Design - Crafting Digital Experiences",
                ReviewDate = DateTime.Now.AddDays(42),
                Review = "Diving into the world of interactive UI design was an enlightening experience. The course provided valuable insights into crafting engaging digital experiences. The hands-on projects allowed me to apply theoretical knowledge to practical scenarios."
            },
            new TraineeCourse
            {
                TraineeID = 14,
                CourseID = 8,
                EnrolledDate = DateTime.Now,
                Rating = 4,
                ReviewTitle = "JavaScript and Frontend Frameworks - Unleashing Interactivity",
                ReviewDate = DateTime.Now.AddDays(35),
                Review = "JavaScript and Frontend Frameworks offered interactive learning experiences. The course content was engaging, and the practical exercises helped me understand the power of JavaScript in building dynamic web applications. The instructor's approach was fantastic."
            },
            new TraineeCourse
            {
                TraineeID = 14,
                CourseID = 13,
                EnrolledDate = DateTime.Now,
                Rating = 5,
                ReviewTitle = "Statistics Fundamentals - A Statistical Journey",
                ReviewDate = DateTime.Now.AddDays(28),
                Review = "Gaining a comprehensive understanding of statistics was a statistical journey. The course covered foundational principles with clarity, and the practical applications enhanced my statistical skills. The real-world examples were particularly beneficial."
            },
            new TraineeCourse
            {
                TraineeID = 14,
                CourseID = 18,
                EnrolledDate = DateTime.Now,
                Rating = 4,
                ReviewTitle = "Physics Essentials - Exploring the Fundamentals",
                ReviewDate = DateTime.Now.AddDays(21),
                Review = "Exploring the fundamental principles of physics and their applications was fascinating. The course content was clear, and the practical examples provided a deep understanding of physics fundamentals. The experiments were particularly enjoyable."
            },
            new TraineeCourse
            {
                TraineeID = 14,
                CourseID = 4,
                EnrolledDate = DateTime.Now,
                Rating = 5,
                ReviewTitle = "Cloud Computing Essentials - Mastering the Cloud",
                ReviewDate = DateTime.Now.AddDays(14),
                Review = "Exploring the fundamentals of cloud computing was a masterclass. The course covered practical skills in using popular cloud platforms, providing a solid foundation for real-world applications. The real-world scenarios were particularly insightful."
            },
         
            new TraineeCourse
            {
                TraineeID = 14,
                CourseID = 10,
                EnrolledDate = DateTime.Now,
                Rating = 5,
                ReviewTitle = "Full-Stack Web Development with MERN Stack - Mastering the Stack",
                ReviewDate = DateTime.Now,
                Review = "Becoming a full-stack developer using the MERN (MongoDB, Express.js, React.js, Node.js) stack was a challenging yet rewarding journey. The course covered the entire stack comprehensively, and the hands-on projects provided practical insights. The real-world applications were particularly beneficial."
            },
            new TraineeCourse
            {
                TraineeID = 15,
                CourseID = 2,
                EnrolledDate = DateTime.Now,
                Rating = 4,
                ReviewTitle = "Advanced Topics in Technology Innovation - Exploring Cutting-Edge Concepts",
                ReviewDate = DateTime.Now.AddDays(63),
                Review = "Diving deep into advanced topics such as artificial intelligence, blockchain, and the Internet of Things was intellectually stimulating. The course content was comprehensive, and the real-world applications provided insights into the latest technological innovations. The hands-on projects were particularly challenging and rewarding."
            },
            new TraineeCourse
            {
                TraineeID = 15,
                CourseID = 15,
                EnrolledDate = DateTime.Now,
                Rating = 5,
                ReviewTitle = "Algebra Basics - Building a Solid Mathematical Foundation",
                ReviewDate = DateTime.Now.AddDays(56),
                Review = "Building a solid foundation in algebraic concepts and problem-solving was fundamental. The course content was well-organized, and the practical exercises enhanced my understanding of algebra basics. The mathematical applications were particularly insightful."
            },
            new TraineeCourse
            {
                TraineeID = 15,
                CourseID = 6,
                EnrolledDate = DateTime.Now,
                Rating = 4,
                ReviewTitle = "Web Development Fundamentals - Building a Strong Foundation",
                ReviewDate = DateTime.Now.AddDays(49),
                Review = "Web Development Fundamentals laid a strong foundation for my journey in web development. The concepts were explained clearly, and the hands-on exercises enhanced my coding skills. The instructor's guidance was invaluable."
            },
            new TraineeCourse
            {
                TraineeID = 15,
                CourseID = 12,
                EnrolledDate = DateTime.Now,
                Rating = 5,
                ReviewTitle = "Interactive UI Design - Crafting Digital Experiences",
                ReviewDate = DateTime.Now.AddDays(42),
                Review = "Diving into the world of interactive UI design was an enlightening experience. The course provided valuable insights into crafting engaging digital experiences. The hands-on projects allowed me to apply theoretical knowledge to practical scenarios."
            },
            new TraineeCourse
            {
                TraineeID = 15,
                CourseID = 8,
                EnrolledDate = DateTime.Now,
                Rating = 4,
                ReviewTitle = "JavaScript and Frontend Frameworks - Unleashing Interactivity",
                ReviewDate = DateTime.Now.AddDays(35),
                Review = "JavaScript and Frontend Frameworks offered interactive learning experiences. The course content was engaging, and the practical exercises helped me understand the power of JavaScript in building dynamic web applications. The instructor's approach was fantastic."
            },
            new TraineeCourse
            {
                TraineeID = 15,
                CourseID = 13,
                EnrolledDate = DateTime.Now,
                Rating = 5,
                ReviewTitle = "Statistics Fundamentals - A Statistical Journey",
                ReviewDate = DateTime.Now.AddDays(28),
                Review = "Gaining a comprehensive understanding of statistics was a statistical journey. The course covered foundational principles with clarity, and the practical applications enhanced my statistical skills. The real-world examples were particularly beneficial."
            },
            new TraineeCourse
            {
                TraineeID = 15,
                CourseID = 18,
                EnrolledDate = DateTime.Now,
                Rating = 4,
                ReviewTitle = "Physics Essentials - Exploring the Fundamentals",
                ReviewDate = DateTime.Now.AddDays(21),
                Review = "Exploring the fundamental principles of physics and their applications was fascinating. The course content was clear, and the practical examples provided a deep understanding of physics fundamentals. The experiments were particularly enjoyable."
            },
            new TraineeCourse
            {
                TraineeID = 15,
                CourseID = 4,
                EnrolledDate = DateTime.Now,
                Rating = 5,
                ReviewTitle = "Cloud Computing Essentials - Mastering the Cloud",
                ReviewDate = DateTime.Now.AddDays(14),
                Review = "Exploring the fundamentals of cloud computing was a masterclass. The course covered practical skills in using popular cloud platforms, providing a solid foundation for real-world applications. The real-world scenarios were particularly insightful."
            },
            new TraineeCourse
            {
                TraineeID = 15,
                CourseID = 17,
                EnrolledDate = DateTime.Now,
                Rating = 4,
                ReviewTitle = "Biology Fundamentals - A Fascinating Journey",
                ReviewDate = DateTime.Now.AddDays(7),
                Review = "Gaining a comprehensive understanding of fundamental biological concepts was fascinating. The course content was well-structured, and the practical applications enhanced my knowledge of biology fundamentals. The exploration of different biological systems was particularly insightful."
            },
            new TraineeCourse
            {
                TraineeID = 15,
                CourseID = 10,
                EnrolledDate = DateTime.Now,
                Rating = 5,
                ReviewTitle = "Full-Stack Web Development with MERN Stack - Mastering the Stack",
                ReviewDate = DateTime.Now,
                Review = "Becoming a full-stack developer using the MERN (MongoDB, Express.js, React.js, Node.js) stack was a challenging yet rewarding journey. The course covered the entire stack comprehensively, and the hands-on projects provided practical insights. The real-world applications were particularly beneficial."
            }
            };
            foreach (var model in TcModels)
            {
                traineeCourseService.Enroll(model);

                var course = courseService.GetCourse(model.CourseID);
                course.EnrolledTrainees++;
                course.Rating = (double)((course.Rating * course.Reviewers) + model.Rating) / (++course.Reviewers);
                courseService.Update(course);
            }
        }
        private static void CreateCoursesForFirstTime()
        {
            var courses = new Course[]
              {
            new Course
            {
                Name = "Introduction to Technology Fundamentals",
                Description = "Learn the basic principles of technology, including hardware, software, and emerging trends.",
                CreatedDate = new DateTime(2022, 01, 15),
                CategoryId = categoryService.GetCategoryByName("Technology")?.Id,
                Promises = "Learn essential technology concepts,Gain problem-solving skills,Understand the role of technology in various industries",
                Topics = "Introduction to Computer Hardware\nBasics of Programming,Cloud Computing Fundamentals,Trends in Technology,Ethical Considerations in Technology",
                Prerequests = "None", // Updated from Prerequisites
                ImageUrl = "Tech1.png",
                Sections = new List<Section>
                {
                    new Section
                    {
                        Name = "Fundamental Concepts",
                        Lessons = new List<Lesson>
                        {
                            new Lesson { Title = "Overview of Technology", Duration = 60, OrderNumber = 1 },
                            new Lesson { Title = "Problem Solving Skills", Duration = 90, OrderNumber = 2 },
                            // Add more lessons as needed
                        }
                    },
                    new Section
                    {
                        Name = "Programming Basics",
                        Lessons = new List<Lesson>
                        {
                            new Lesson { Title = "Introduction to Programming Languages", Duration = 75, OrderNumber = 1 },
                            new Lesson { Title = "Programming Logic and Flow", Duration = 120, OrderNumber = 2 },
                            // Add more lessons as needed
                        }
                    },
                    new Section
                    {
                        Name = "Advanced Topics in Hardware",
                        Lessons = new List<Lesson>
                        {
                            new Lesson { Title = "Advanced Computer Architecture", Duration = 90, OrderNumber = 1 },
                            new Lesson { Title = "Hardware Optimization Techniques", Duration = 105, OrderNumber = 2 },
                            // Add more lessons as needed
                        }
                    },
                    // Add more sections as needed
                },
                TrainerId = trainerService.GetTrainerByEmail("amir.hamza@example.com").Id

            },
            new Course

            {
                Name = "Advanced Topics in Technology Innovation",
                Description = "Dive deep into advanced topics such as artificial intelligence, blockchain, and the Internet of Things.",
                CreatedDate = new DateTime(2022, 05, 20),
                CategoryId =categoryService.GetCategoryByName("Technology")?.Id,
                Promises = "Master advanced technology concepts,Gain hands-on experience with cutting-edge tools,Explore real-world applications of emerging technologies",
                Topics = "Artificial Intelligence and Machine Learning,Blockchain Technology,Internet of Things (IoT),Quantum Computing,Augmented and Virtual Reality",
                Prerequests = "Introduction to Technology Fundamentals or equivalent knowledge", // Updated from Prerequisites
                Sections = new List<Section>
                {
                    new Section
                    {
                        Name = "Cutting-edge Technologies",
                        Lessons = new List<Lesson>
                        {
                            new Lesson { Title = "Artificial Intelligence Overview", Duration= 120, OrderNumber = 1 },
                            new Lesson { Title = "Blockchain Technology in Depth", Duration= 90, OrderNumber = 2 },
                            // Add more lessons as needed
                        }
                    },
                    new Section
                    {
                        Name = "Practical Applications",
                        Lessons = new List<Lesson>
                        {
                            new Lesson { Title = "Real-world IoT Implementations", Duration = 105, OrderNumber = 1 },
                            new Lesson { Title = "Quantum Computing in Practice", Duration = 120, OrderNumber = 2 },
                            // Add more lessons as needed
                        }
                    },
                    new Section
                    {
                        Name = "Advanced Reality Technologies",
                        Lessons = new List<Lesson>
                        {
                            new Lesson { Title = "Augmented Reality in Industry", Duration = 90, OrderNumber = 1 },
                            new Lesson { Title = "Virtual Reality Development", Duration = 105, OrderNumber = 2 },
                            // Add more lessons as needed
                        }
                    },
                },
                TrainerId = trainerService.GetTrainerByEmail("amir.hamza@example.com").Id,
                ImageUrl = "Tech2.png",

            },
            new Course
{
    Name = "DevOps Foundations",
    Description = "Understand the principles and practices of DevOps, focusing on collaboration between development and operations teams.",
    CreatedDate = new DateTime(2021, 11, 10),
    CategoryId = categoryService.GetCategoryByName("Cybersecurity")?.Id,
    Promises = "Master DevOps principles and practices,Gain hands-on experience with DevOps tools,Learn to automate the software development process",
    Topics = "Introduction to DevOps,Continuous Integration and Deployment,Infrastructure as Code (IaC),Monitoring and Logging,DevOps Best Practices",
    Prerequests = "Basic understanding of software development and system administration",
    Sections = new List<Section>
    {
        new Section
        {
            Name = "Foundational DevOps",
            Lessons = new List<Lesson>
            {
                new Lesson { Title = "Introduction to DevOps", Duration = 90, OrderNumber = 1 },
                new Lesson { Title = "Continuous Integration Practices", Duration = 120, OrderNumber = 2 },
                // Add more lessons as needed
            }
        },
        new Section
        {
            Name = "Infrastructure as Code",
            Lessons = new List<Lesson>
            {
                new Lesson { Title = "Understanding IaC Concepts", Duration = 90, OrderNumber = 1 },
                new Lesson { Title = "Implementing IaC with Terraform", Duration = 150, OrderNumber = 2 },
                // Add more lessons as needed
            }
        },
        new Section
        {
            Name = "Deployment Strategies",
            Lessons = new List<Lesson>
            {
                new Lesson { Title = "Blue-Green Deployments", Duration = 120, OrderNumber = 1 },
                new Lesson { Title = "Canary Releases", Duration = 90, OrderNumber = 2 },
                // Add more lessons as needed
            }
        },
        new Section
        {
            Name = "Advanced Monitoring",
            Lessons = new List<Lesson>
            {
                new Lesson { Title = "Log Analysis and Centralized Logging", Duration = 120, OrderNumber = 1 },
                new Lesson { Title = "Monitoring Infrastructure with Prometheus", Duration = 150, OrderNumber = 2 },
                // Add more lessons as needed
            }
        },
        // Add more sections as needed
    },
    ImageUrl = "Tech3.png",
            TrainerId = trainerService.GetTrainerByEmail("ahmed.khalid@example.com").Id
},
            new Course
{
    Name = "Cloud Computing Essentials",
    Description = "Explore the fundamentals of cloud computing and gain practical skills in using popular cloud platforms.",
    CreatedDate = new DateTime(2022, 03, 05),
    CategoryId =categoryService.GetCategoryByName("Cybersecurity")?.Id,
    Promises = "Understand cloud computing concepts,Gain hands-on experience with cloud platforms,Learn to design and deploy scalable cloud solutions",
    Topics = "Introduction to Cloud Computing,Cloud Service Models (IaaS, PaaS, SaaS),Cloud Deployment Models (Public, Private, Hybrid),Cloud Security and Compliance,Scalability and Performance Optimization",
    Prerequests = "Basic understanding of networking and web technologies",
    Sections = new List<Section>
    {
        new Section
        {
            Name = "Cloud Fundamentals",
            Lessons = new List<Lesson>
            {
                new Lesson { Title = "Introduction to Cloud Computing", Duration = 90, OrderNumber = 1 },
                new Lesson { Title = "Cloud Service Models", Duration = 120, OrderNumber = 2 },
                // Add more lessons as needed
            }
        },
        new Section
        {
            Name = "Advanced Cloud Services",
            Lessons = new List<Lesson>
            {
                new Lesson { Title = "Serverless Computing with AWS Lambda", Duration = 150, OrderNumber = 1 },
                new Lesson { Title = "Containers and Orchestration with Kubernetes", Duration = 120, OrderNumber = 2 },
                // Add more lessons as needed
            }
        },
        new Section
        {
            Name = "Hybrid Cloud Environments",
            Lessons = new List<Lesson>
            {
                new Lesson { Title = "Implementing Hybrid Cloud Solutions", Duration = 120, OrderNumber = 1 },
                new Lesson { Title = "Managing Multi-Cloud Environments", Duration = 150, OrderNumber = 2 },
                // Add more lessons as needed
            }
        },
        new Section
        {
            Name = "Security Best Practices",
            Lessons = new List<Lesson>
            {
                new Lesson { Title = "Cloud Security Principles", Duration = 90, OrderNumber = 1 },
                new Lesson { Title = "Implementing Identity and Access Management", Duration = 120, OrderNumber = 2 },
                // Add more lessons as needed
            }
        },
        // Add more sections as needed
    },
     TrainerId = trainerService.GetTrainerByEmail("amir.hamza@example.com").Id,
                ImageUrl = "Tech4.png",
},
            new Course
{
    Name = "Emerging Technologies in Cybersecurity",
    Description = "Stay ahead of cyber threats by exploring the latest trends and technologies in cybersecurity.",
    CreatedDate = new DateTime(2022, 08, 18),
    CategoryId = categoryService.GetCategoryByName("Cybersecurity")?.Id,
    Promises = "Understand emerging trends in cybersecurity,Gain practical skills in threat detection and response,Learn to secure systems against evolving threats",
    Topics = "Threat Intelligence and Analysis,Security Automation and Orchestration,Zero Trust Security Model,Cloud Security,Incident Response and Recovery",
    Prerequests = "Basic knowledge of cybersecurity principles",
    Sections = new List<Section>
    {
        new Section
        {
            Name = "Cybersecurity Trends",
            Lessons = new List<Lesson>
            {
                new Lesson { Title = "Introduction to Cybersecurity Trends", Duration = 90, OrderNumber = 1 },
                new Lesson { Title = "Security Automation Strategies", Duration = 120, OrderNumber = 2 },
                new Lesson { Title = "Zero Trust Security Implementation", Duration = 90, OrderNumber = 3 },
                // Add more lessons as needed
            }
        },
        new Section
        {
            Name = "Advanced Threat Intelligence",
            Lessons = new List<Lesson>
            {
                new Lesson { Title = "Advanced Threat Detection Techniques", Duration = 120, OrderNumber = 1 },
                new Lesson { Title = "Threat Intelligence Sharing and Collaboration", Duration = 90, OrderNumber = 2 },
                // Add more lessons as needed
            }
        },
        new Section
        {
            Name = "Cloud Security Best Practices",
            Lessons = new List<Lesson>
            {
                new Lesson { Title = "Securing Cloud Infrastructure", Duration = 120, OrderNumber = 1 },
                new Lesson { Title = "Compliance in Cloud Environments", Duration = 90, OrderNumber = 2 },
                // Add more lessons as needed
            }
        },
        // Add more sections as needed
    },
         TrainerId = trainerService.GetTrainerByEmail("amir.hamza@example.com").Id,
                ImageUrl = "Tech5.png",
},
            new Course
{
    Name = "Web Development Fundamentals",
    Description = "Build a strong foundation in web development with essential concepts and hands-on experience.",
    CreatedDate = new DateTime(2022, 09, 01),
    CategoryId = categoryService.GetCategoryByName("Web Development")?.Id,
    Promises = "Master the basics of web development,Create responsive and dynamic web pages,Understand client-server architecture",
    Topics = "HTML5 and CSS3,JavaScript and DOM manipulation,Responsive Web Design,Introduction to Frontend Frameworks",
    Prerequests = "Basic understanding of HTML and CSS",
    Sections = new List<Section>
    {
        new Section
        {
            Name = "HTML and CSS Essentials",
            Lessons = new List<Lesson>
            {
                new Lesson { Title = "Introduction to HTML5", Duration = 90, OrderNumber = 1 },
                new Lesson { Title = "CSS Styling Techniques", Duration = 120, OrderNumber = 2 },
                // Add more lessons as needed
            }
        },
        new Section
        {
            Name = "JavaScript Basics",
            Lessons = new List<Lesson>
            {
                new Lesson { Title = "JavaScript Fundamentals", Duration = 90, OrderNumber = 1 },
                new Lesson { Title = "DOM Manipulation", Duration = 120, OrderNumber = 2 },
                // Add more lessons as needed
            }
        },
        // Add more sections as needed
    }
    ,
         TrainerId = trainerService.GetTrainerByEmail("ahmed.khalid@example.com").Id,
                ImageUrl = "Tech6.png",
},
            new Course
{
    Name = "Responsive Web Design and CSS Frameworks",
    Description = "Learn to create responsive and visually appealing web pages using CSS frameworks.",
    CreatedDate = new DateTime(2022, 09, 15),
    CategoryId =  categoryService.GetCategoryByName("Web Development")?.Id,
    Promises = "Master responsive web design principles,Use popular CSS frameworks effectively,Create mobile-friendly web pages",
    Topics = "Responsive Design Principles,Bootstrap Framework,Tailwind CSS,Responsive Images and Media",
    Prerequests = "Basic knowledge of HTML and CSS",
    Sections = new List<Section>
    {
        new Section
        {
            Name = "Responsive Design Basics",
            Lessons = new List<Lesson>
            {
                new Lesson { Title = "Understanding Viewports and Media Queries", Duration = 90, OrderNumber = 1 },
                new Lesson { Title = "Building Responsive Layouts", Duration = 120, OrderNumber = 2 },
                // Add more lessons as needed
            }
        },
        new Section
        {
            Name = "CSS Frameworks",
            Lessons = new List<Lesson>
            {
                new Lesson { Title = "Introduction to Bootstrap", Duration = 90, OrderNumber = 1 },
                new Lesson { Title = "Styling with Tailwind CSS", Duration = 120, OrderNumber = 2 },
                // Add more lessons as needed
            }
        },
        // Add more sections as needed
    }
    ,
         TrainerId = trainerService.GetTrainerByEmail("ahmed.khalid@example.com").Id,
                ImageUrl = "Tech7.png",
},
            new Course
{
    Name = "JavaScript and Frontend Frameworks",
    Description = "Explore the power of JavaScript and popular frontend frameworks for building dynamic web applications.",
    CreatedDate = new DateTime(2022, 10, 01),
    CategoryId =  categoryService.GetCategoryByName("Web Development")?.Id,
    Promises = "Master JavaScript for web development,Explore popular frontend frameworks,Create interactive and dynamic web applications",
    Topics = "Advanced JavaScript Concepts,React.js Basics,Vue.js Basics,State Management in Frontend",
    Prerequests = "Solid understanding of HTML, CSS, and basic JavaScript",
    Sections = new List<Section>
    {
        new Section
        {
            Name = "Advanced JavaScript",
            Lessons = new List<Lesson>
            {
                new Lesson { Title = "Asynchronous JavaScript and Promises", Duration = 90, OrderNumber = 1 },
                new Lesson { Title = "ES6 and Modern JavaScript Features", Duration = 120, OrderNumber = 2 },
                // Add more lessons as needed
            }
        },
        new Section
        {
            Name = "Frontend Frameworks",
            Lessons = new List<Lesson>
            {
                new Lesson { Title = "Introduction to React.js", Duration = 90, OrderNumber = 1 },
                new Lesson { Title = "Getting Started with Vue.js", Duration = 120, OrderNumber = 2 },
                // Add more lessons as needed
            }
        },
    },
         TrainerId = trainerService.GetTrainerByEmail("ahmed.khalid@example.com").Id,
                ImageUrl = "Tech8.png",

},
            ///////////////////
           new Course
{
    Name = "Backend Development with Node.js and Express",
    Description = "Build powerful server-side applications using Node.js and the Express framework.",
    CreatedDate = new DateTime(2022, 10, 15),
    CategoryId =  categoryService.GetCategoryByName("Web Development")?.Id,
    Promises = "Master backend development with Node.js,Create RESTful APIs with Express,Understand server-side architecture",
    Topics = "Introduction to Node.js,Express.js Fundamentals,RESTful API Design,Middleware and Routing",
    Prerequests = "Basic knowledge of JavaScript and web development",
    Sections = new List<Section>
    {
        new Section
        {
            Name = "Getting Started with Node.js",
            Lessons = new List<Lesson>
            {
                new Lesson { Title = "Introduction to Node.js", Duration = 90, OrderNumber = 1 },
                new Lesson { Title = "Asynchronous Programming with Node.js", Duration = 120, OrderNumber = 2 },
                // Add more lessons as needed
            }
        },
        new Section
        {
            Name = "Express.js and API Development",
            Lessons = new List<Lesson>
            {
                new Lesson { Title = "Fundamentals of Express.js", Duration = 90, OrderNumber = 1 },
                new Lesson { Title = "Building RESTful APIs", Duration = 120, OrderNumber = 2 },
                // Add more lessons as needed
            }
        },
        // Add more sections as needed
    },
         TrainerId = trainerService.GetTrainerByEmail("ahmed.khalid@example.com").Id,
                ImageUrl = "Tech9.png",
},
            new Course
{
    Name = "Full-Stack Web Development with MERN Stack",
    Description = "Become a full-stack developer using the MERN (MongoDB, Express.js, React.js, Node.js) stack.",
    CreatedDate = new DateTime(2022, 11, 01),
    CategoryId = categoryService.GetCategoryByName("Web Development")?.Id,
    Promises = "Master the MERN stack for full-stack development,Create modern and scalable web applications,Understand the integration of frontend and backend technologies",
    Topics = "MongoDB Basics,Integration of React.js with Node.js,State Management in MERN Stack,Authentication and Authorization",
    Prerequests = "Solid understanding of JavaScript,HTML, CSS, and basic web development concepts",
    Sections = new List<Section>
    {
        new Section
        {
            Name = "MongoDB and Backend Integration",
            Lessons = new List<Lesson>
            {
                new Lesson { Title = "Introduction to MongoDB", Duration = 90, OrderNumber = 1 },
                new Lesson { Title = "Connecting React.js with Node.js and MongoDB", Duration = 120, OrderNumber = 2 },
                // Add more lessons as needed
            }
        },
        new Section
        {
            Name = "State Management and Authentication",
            Lessons = new List<Lesson>
            {
                new Lesson { Title = "State Management in React.js", Duration = 90, OrderNumber = 1 },
                new Lesson { Title = "Implementing Authentication and Authorization", Duration = 120, OrderNumber = 2 },
                // Add more lessons as needed
            }
        },

    },
    TrainerId = trainerService.GetTrainerByEmail("ahmed.khalid@example.com").Id,
                ImageUrl = "Tech10.png",
},
            new Course
{
    Name = "UX/UI Fundamentals",
    Description = "Explore the foundational principles of User Experience (UX) and User Interface (UI) design.",
    CreatedDate = new DateTime(2023, 01, 10),
    CategoryId = categoryService.GetCategoryByName("UX/UI Design")?.Id,
    Promises = "Understand the basics of UX/UI design,Learn user-centered design principles,Create visually appealing user interfaces",
    Topics = "Introduction to UX/UI Design,User Research and Personas,Information Architecture,Wireframing and Prototyping,Visual Design Principles",
    Prerequests = "Basic understanding of design concepts",
    Sections = new List<Section>
    {
        new Section
        {
            Name = "Introduction to UX/UI",
            Lessons = new List<Lesson>
            {
                new Lesson { Title = "Overview of UX/UI Design", Duration = 90, OrderNumber = 1 },
                new Lesson { Title = "Importance of User-Centered Design", Duration = 120, OrderNumber = 2 },
                // Add more lessons as needed
            }
        },
        new Section
        {
            Name = "User Research",
            Lessons = new List<Lesson>
            {
                new Lesson { Title = "Conducting User Interviews", Duration = 90, OrderNumber = 1 },
                new Lesson { Title = "Creating User Personas", Duration = 120, OrderNumber = 2 },
                // Add more lessons as needed
            }
        },

    },
    TrainerId = trainerService.GetTrainerByEmail("omar.abdullah@example.com").Id,
       ImageUrl = "Tech11.png",
},
            new Course
{
    Name = "Interactive UI Design",
    Description = "Dive into the world of interactive user interface design and create engaging digital experiences.",
    CreatedDate = new DateTime(2023, 02, 20),
    CategoryId = categoryService.GetCategoryByName("UX/UI Design")?.Id,
    Promises = "Master interactive UI design principles,Create responsive and interactive interfaces,Understand user interaction patterns",
    Topics = "Advanced Visual Design,Responsive UI Design,Interaction Design Patterns,UI Animation Techniques,Prototyping with Interaction",
    Prerequests = "Basic knowledge of UX/UI fundamentals",
    Sections = new List<Section>
    {
        new Section
        {
            Name = "Advanced Visual Design",
            Lessons = new List<Lesson>
            {
                new Lesson { Title = "Color Theory and Application", Duration = 90, OrderNumber = 1 },
                new Lesson { Title = "Typography in UI Design", Duration = 120, OrderNumber = 2 },
                // Add more lessons as needed
            }
        },
        new Section
        {
            Name = "Responsive UI Design",
            Lessons = new List<Lesson>
            {
                new Lesson { Title = "Creating Responsive Layouts", Duration = 90, OrderNumber = 1 },
                new Lesson { Title = "Adaptive Design Techniques", Duration = 120, OrderNumber = 2 },
                // Add more lessons as needed
            }
        },
        // Add more sections as needed
    },
        TrainerId = trainerService.GetTrainerByEmail("omar.abdullah@example.com").Id,
       ImageUrl = "Tech12.png",
},
          
            new Course
{
    Name = "Statistics Fundamentals",
    Description = "Learn the foundational principles of statistics and data analysis.",
    CreatedDate = new DateTime(2023, 04, 01),
    CategoryId = categoryService.GetCategoryByName("Statistics")?.Id,
    Promises = "Understand statistical concepts,Gain practical data analysis skills,Learn to interpret statistical results",
    Topics = "Descriptive Statistics,Inferential Statistics,Probability Distributions,Hypothesis Testing,Regression Analysis",
    Prerequests = "Basic understanding of mathematics",
    ImageUrl = "Tech13.png",
            TrainerId = trainerService.GetTrainerByEmail("ahmed.almansoori@example.com").Id,

    Sections = new List<Section>
    {
        new Section
        {
            Name = "Introduction to Statistics",
            Lessons = new List<Lesson>
            {
                new Lesson { Title = "Overview of Statistics", Duration = 90, OrderNumber = 1 },
                new Lesson { Title = "Descriptive Statistics", Duration = 120, OrderNumber = 2 },
                // Add more lessons as needed
            }
        },
        new Section
        {
            Name = "Inferential Statistics",
            Lessons = new List<Lesson>
            {
                new Lesson { Title = "Probability and Sampling", Duration = 90, OrderNumber = 1 },
                new Lesson { Title = "Hypothesis Testing", Duration = 120, OrderNumber = 2 },
                // Add more lessons as needed
            }
        },
        // Add more sections as needed
    }
},
            new Course
{
    Name = "Calculus Principles",
    Description = "Dive into the fundamental principles of calculus and mathematical analysis.",
    CreatedDate = new DateTime(2023, 04, 02),
    CategoryId = categoryService.GetCategoryByName("Calculus")?.Id,
    Promises = "Master calculus concepts,Understand mathematical analysis,Apply calculus in real-world scenarios",
    Topics = "Limits and Continuity,Differentiation,Integration,Applications of Calculus,Multivariable Calculus",
    Prerequests = "Solid foundation in algebra and trigonometry",
    ImageUrl = "Tech14.png",
            TrainerId = trainerService.GetTrainerByEmail("zayd.alqasimi@example.com").Id,

    Sections = new List<Section>
    {
        new Section
        {
            Name = "Limits and Continuity",
            Lessons = new List<Lesson>
            {
                new Lesson { Title = "Understanding Limits", Duration = 90, OrderNumber = 1 },
                new Lesson { Title = "Continuity in Functions", Duration = 120, OrderNumber = 2 },
                // Add more lessons as needed
            }
        },
        new Section
        {
            Name = "Differentiation",
            Lessons = new List<Lesson>
            {
                new Lesson { Title = "Derivatives and Rates of Change", Duration = 90, OrderNumber = 1 },
                new Lesson { Title = "Applications of Derivatives", Duration = 120, OrderNumber = 2 },
                // Add more lessons as needed
            }
        },
        // Add more sections as needed
    }
},
            new Course
{
    Name = "Algebra Basics",
    Description = "Build a strong foundation in algebraic concepts and problem-solving.",
    CreatedDate = new DateTime(2023, 04, 03),
    CategoryId = categoryService.GetCategoryByName("Algebra")?.Id,
    Promises = "Master algebraic principles,Solve complex equations and inequalities,Apply algebra in various domains",
    Topics = "Linear Algebra,Quadratic Equations,Systems of Equations,Polynomials,Exponential and Logarithmic Functions",
    Prerequests = "Basic understanding of arithmetic",
    ImageUrl = "Tech15.png",
                TrainerId = trainerService.GetTrainerByEmail("zayd.alqasimi@example.com").Id,

    Sections = new List<Section>
    {
        new Section
        {
            Name = "Linear Algebra",
            Lessons = new List<Lesson>
            {
                new Lesson { Title = "Introduction to Linear Equations", Duration = 90, OrderNumber = 1 },
                new Lesson { Title = "Matrix Operations", Duration = 120, OrderNumber = 2 },
                // Add more lessons as needed
            }
        },
        new Section
        {
            Name = "Quadratic Equations",
            Lessons = new List<Lesson>
            {
                new Lesson { Title = "Solving Quadratic Equations", Duration = 90, OrderNumber = 1 },
                new Lesson { Title = "Applications of Quadratics", Duration = 120, OrderNumber = 2 },
                // Add more lessons as needed
            }
        },
        // Add more sections as needed
    }
},
            new Course
{
    Name = "Introduction to Painting",
    Description = "Explore the world of visual arts and develop your painting skills.",
    CreatedDate = new DateTime(2023, 04, 04),
    CategoryId = categoryService.GetCategoryByName("Painting")?.Id,
    Promises = "Learn painting techniques,Express creativity through art,Understand the history of painting",
    Topics = "Color Theory and Mixing,Brush Techniques,Composition in Painting,Artistic Styles,Art Critique",
    Prerequests = "None",
    ImageUrl = "Tech16.png",
   TrainerId = trainerService.GetTrainerByEmail("jamal.farid@example.com").Id,

    Sections = new List<Section>
    {
        new Section
        {
            Name = "Foundations of Painting",
            Lessons = new List<Lesson>
            {
                new Lesson { Title = "Color Theory Basics", Duration = 90, OrderNumber = 1 },
                new Lesson { Title = "Introduction to Brush Techniques", Duration = 120, OrderNumber = 2 },
                // Add more lessons as needed
            }
        },
        new Section
        {
            Name = "Composition and Styles",
            Lessons = new List<Lesson>
            {
                new Lesson { Title = "Creating a Strong Composition", Duration = 90, OrderNumber = 1 },
                new Lesson { Title = "Exploring Artistic Styles", Duration = 120, OrderNumber = 2 },
                // Add more lessons as needed
            }
        },
        // Add more sections as needed
    }
},
            
            new Course
{
    Name = "Biology Fundamentals",
    Description = "Gain a comprehensive understanding of fundamental biological concepts.",
    CreatedDate = new DateTime(2023, 04, 05),
    CategoryId = categoryService.GetCategoryByName("Biology")?.Id,
    Promises = "Explore basic biological principles,Understand cellular biology,Learn about ecosystems and biodiversity",
    Topics = "Cell Structure and Function,Genetics and Heredity,Ecology and Ecosystems,Evolutionary Biology,Human Anatomy and Physiology",
    Prerequests = "Basic understanding of science",
    ImageUrl = "Tech17.png",
                TrainerId = trainerService.GetTrainerByEmail("salah.aldin@example.com").Id,

    Sections = new List<Section>
    {
        new Section
        {
            Name = "Cell Biology",
            Lessons = new List<Lesson>
            {
                new Lesson { Title = "Introduction to Cell Biology", Duration = 90, OrderNumber = 1 },
                new Lesson { Title = "Cellular Processes", Duration = 120, OrderNumber = 2 },
                // Add more lessons as needed
            }
        },
        new Section
        {
            Name = "Genetics and Evolution",
            Lessons = new List<Lesson>
            {
                new Lesson { Title = "Principles of Genetics", Duration = 90, OrderNumber = 1 },
                new Lesson { Title = "Understanding Evolution", Duration = 120, OrderNumber = 2 },
                // Add more lessons as needed
            }
        },
        // Add more sections as needed
    }
},
            new Course
{
    Name = "Physics Essentials",
    Description = "Explore the fundamental principles of physics and their applications.",
    CreatedDate = new DateTime(2023, 04, 06),
    CategoryId = categoryService.GetCategoryByName("Physics")?.Id,
    Promises = "Understand classical physics principles,Learn about motion and forces,Explore energy and thermodynamics",
    Topics = "Classical Mechanics,Electricity and Magnetism,Thermodynamics,Optics,Waves and Sound",
    Prerequests = "Basic understanding of mathematics",
    ImageUrl = "Tech18.png",
                TrainerId = trainerService.GetTrainerByEmail("salah.aldin@example.com").Id,

    Sections = new List<Section>
    {
        new Section
        {
            Name = "Classical Mechanics",
            Lessons = new List<Lesson>
            {
                new Lesson { Title = "Introduction to Mechanics", Duration = 90, OrderNumber = 1 },
                new Lesson { Title = "Newton's Laws of Motion", Duration = 120, OrderNumber = 2 },
                // Add more lessons as needed
            }
        },
        new Section
        {
            Name = "Electricity and Magnetism",
            Lessons = new List<Lesson>
            {
                new Lesson { Title = "Electric Fields and Circuits", Duration = 90, OrderNumber = 1 },
                new Lesson { Title = "Magnetic Fields and Electromagnetism", Duration = 120, OrderNumber = 2 },
                // Add more lessons as needed
            }
        },
        // Add more sections as needed
    }
},
            new Course
{
    Name = "Chemistry Fundamentals",
    Description = "Explore the basic principles of chemistry and chemical reactions.",
    CreatedDate = new DateTime(2023, 04, 07),
    CategoryId = categoryService.GetCategoryByName("Chemistry")?.Id,
    Promises = "Understand chemical structures and properties,Explore chemical reactions and kinetics,Learn about the periodic table",
    Topics = "Atomic Structure and Bonding,Chemical Reactions and Equations,Thermodynamics,Periodic Table and Elements,Organic Chemistry",
    Prerequests = "Basic understanding of science",
    ImageUrl = "Tech19.png",
                    TrainerId = trainerService.GetTrainerByEmail("salah.aldin@example.com").Id,

    Sections = new List<Section>
    {
        new Section
        {
            Name = "Atomic Structure",
            Lessons = new List<Lesson>
            {
                new Lesson { Title = "Introduction to Atoms and Elements", Duration = 90, OrderNumber = 1 },
                new Lesson { Title = "Chemical Bonding", Duration = 120, OrderNumber = 2 },
                // Add more lessons as needed
            }
        },
        new Section
        {
            Name = "Chemical Reactions",
            Lessons = new List<Lesson>
            {
                new Lesson { Title = "Types of Chemical Reactions", Duration = 90, OrderNumber = 1 },
                new Lesson { Title = "Reaction Kinetics", Duration = 120, OrderNumber = 2 },
                // Add more lessons as needed
            }
        },
        // Add more sections as needed
    }
},
            
              };

            foreach (var course in courses)
            {
                courseService.Add(course);
            }
        }
        private static void CreateTraineesForFirstTime()
        {
            var traineeData = new RegisterViewModel[]
{
    new RegisterViewModel
    {
        Name = "Adnan Farouk",
        Email = "adnan.farouk@example.com",
        PhoneNumber = "111111111",
        AccountType = "Trainee",
        Password = "mohamed11",
        ConfirmPassword = "mohamed11"
    },
    new RegisterViewModel
    {
        Name = "Fahad Al-Hassan",
        Email = "fahad.alhassan@example.com",
        PhoneNumber = "222222222",
        AccountType = "Trainee",
        Password = "mohamed11",
        ConfirmPassword = "mohamed11"
    },
    new RegisterViewModel
    {
        Name = "Ziad Mansour",
        Email = "ziad.mansour@example.com",
        PhoneNumber = "333333333",
        AccountType = "Trainee",
        Password = "mohamed11",
        ConfirmPassword = "mohamed11"
    },
    new RegisterViewModel
    {
        Name = "Raed Al-Mubarak",
        Email = "raed.almubarak@example.com",
        PhoneNumber = "444444444",
        AccountType = "Trainee",
        Password = "mohamed11",
        ConfirmPassword = "mohamed11"
    },
    new RegisterViewModel
    {
        Name = "Khalid Badawi",
        Email = "khalid.badawi@example.com",
        PhoneNumber = "555555555",
        AccountType = "Trainee",
        Password = "mohamed11",
        ConfirmPassword = "mohamed11"
    },
    new RegisterViewModel
    {
        Name = "Faisal Al-Rawi",
        Email = "faisal.alrawi@example.com",
        PhoneNumber = "666666666",
        AccountType = "Trainee",
        Password = "mohamed11",
        ConfirmPassword = "mohamed11"
    },
    new RegisterViewModel
    {
        Name = "Walid Abdel-Rahman",
        Email = "walid.abdelrahman@example.com",
        PhoneNumber = "777777777",
        AccountType = "Trainee",
        Password = "mohamed11",
        ConfirmPassword = "mohamed11"
    },
    new RegisterViewModel
    {
        Name = "Nizar Al-Qassab",
        Email = "nizar.alqassab@example.com",
        PhoneNumber = "888888888",
        AccountType = "Trainee",
        Password = "mohamed11",
        ConfirmPassword = "mohamed11"
    },
    new RegisterViewModel
    {
        Name = "Bilal Al-Jabari",
        Email = "bilal.aljabari@example.com",
        PhoneNumber = "999999999",
        AccountType = "Trainee",
        Password = "mohamed11",
        ConfirmPassword = "mohamed11"
    },
    new RegisterViewModel
    {
        Name = "Tarek Al-Amin",
        Email = "tarek.alamin@example.com",
        PhoneNumber = "123123123",
        AccountType = "Trainee",
        Password = "mohamed11",
        ConfirmPassword = "mohamed11"
    }
    ,
      new RegisterViewModel
    {
        Name = "Ahmed Al-Baroudi",
        Email = "ahmed.albaroudi@example.com",
        PhoneNumber = "111111111",
        AccountType = "Trainee",
        Password = "mohamed11",
        ConfirmPassword = "mohamed11"
    },
    new RegisterViewModel
    {
        Name = "Rami Al-Falah",
        Email = "rami.alfalah@example.com",
        PhoneNumber = "222222222",
        AccountType = "Trainee",
        Password = "mohamed11",
        ConfirmPassword = "mohamed11"
    },
    new RegisterViewModel
    {
        Name = "Youssef Al-Khouri",
        Email = "youssef.alkhouri@example.com",
        PhoneNumber = "333333333",
        AccountType = "Trainee",
        Password = "mohamed11",
        ConfirmPassword = "mohamed11"
    },
    new RegisterViewModel
    {
        Name = "Karim Al-Masri",
        Email = "karim.almasri@example.com",
        PhoneNumber = "444444444",
        AccountType = "Trainee",
        Password = "mohamed11",
        ConfirmPassword = "mohamed11"
    },
    new RegisterViewModel
    {
        Name = "Sami Al-Attar",
        Email = "sami.alattar@example.com",
        PhoneNumber = "555555555",
        AccountType = "Trainee",
        Password = "mohamed11",
        ConfirmPassword = "mohamed11"
    },
    new RegisterViewModel
    {
        Name = "Nabeel Al-Hadi",
        Email = "nabeel.alhadi@example.com",
        PhoneNumber = "666666666",
        AccountType = "Trainee",
        Password = "mohamed11",
        ConfirmPassword = "mohamed11"
    },
    new RegisterViewModel
    {
        Name = "Jawad Al-Zubair",
        Email = "jawad.alzubair@example.com",
        PhoneNumber = "777777777",
        AccountType = "Trainee",
        Password = "mohamed11",
        ConfirmPassword = "mohamed11"
    },
    new RegisterViewModel
    {
        Name = "Malik Al-Saeed",
        Email = "malik.alsaeed@example.com",
        PhoneNumber = "888888888",
        AccountType = "Trainee",
        Password = "mohamed11",
        ConfirmPassword = "mohamed11"
    },
    new RegisterViewModel
    {
        Name = "Hadi Al-Amiri",
        Email = "hadi.alamiri@example.com",
        PhoneNumber = "999999999",
        AccountType = "Trainee",
        Password = "mohamed11",
        ConfirmPassword = "mohamed11"
    },
    new RegisterViewModel
    {
        Name = "Majid Al-Khalil",
        Email = "majid.alkhalil@example.com",
        PhoneNumber = "123123123",
        AccountType = "Trainee",
        Password = "mohamed11",
        ConfirmPassword = "mohamed11"
    },
    new RegisterViewModel
    {
        Name = "Khaled Al-Ashraf",
        Email = "khaled.alashraf@example.com",
        PhoneNumber = "456456456",
        AccountType = "Trainee",
        Password = "mohamed11",
        ConfirmPassword = "mohamed11"
    },
    new RegisterViewModel
    {
        Name = "Jamal Al-Turk",
        Email = "jamal.alturk@example.com",
        PhoneNumber = "789789789",
        AccountType = "Trainee",
        Password = "mohamed11",
        ConfirmPassword = "mohamed11"
    },
    new RegisterViewModel
    {
        Name = "Mustafa Al-Qarni",
        Email = "mustafa.alqarni@example.com",
        PhoneNumber = "987987987",
        AccountType = "Trainee",
        Password = "mohamed11",
        ConfirmPassword = "mohamed11"
    },
    new RegisterViewModel
    {
        Name = "Imad Al-Mahmoud",
        Email = "imad.almahmoud@example.com",
        PhoneNumber = "654654654",
        AccountType = "Trainee",
        Password = "mohamed11",
        ConfirmPassword = "mohamed11"
    },
    new RegisterViewModel
    {
        Name = "Rafiq Al-Sabah",
        Email = "rafiq.alsabah@example.com",
        PhoneNumber = "321321321",
        AccountType = "Trainee",
        Password = "mohamed11",
        ConfirmPassword = "mohamed11"
    },
    new RegisterViewModel
    {
        Name = "Talal Al-Khatib",
        Email = "talal.alkhatib@example.com",
        PhoneNumber = "111222333",
        AccountType = "Trainee",
        Password = "mohamed11",
        ConfirmPassword = "mohamed11"
    },
    new RegisterViewModel
    {
        Name = "Saleh Al-Din",
        Email = "saleh.aldin@example.com",
        PhoneNumber = "444555666",
        AccountType = "Trainee",
        Password = "mohamed11",
        ConfirmPassword = "mohamed11"
    },
    new RegisterViewModel
    {
        Name = "Nasser Al-Khazraji",
        Email = "nasser.alkhazraji@example.com",
        PhoneNumber = "777888999",
        AccountType = "Trainee",
        Password = "mohamed11",
        ConfirmPassword = "mohamed11"
    },
    new RegisterViewModel
    {
        Name = "Mohsen Al-Saleh",
        Email = "mohsen.alsaleh@example.com",
        PhoneNumber = "999888777",
        AccountType = "Trainee",
        Password = "mohamed11",
        ConfirmPassword = "mohamed11"
    },
    new RegisterViewModel
    {
        Name = "Omar Al-Ghazi",
        Email = "omar.alghazi@example.com",
        PhoneNumber = "555666444",
        AccountType = "Trainee",
        Password = "mohamed11",
        ConfirmPassword = "mohamed11"
    },
     new RegisterViewModel
    {
        Name = "Qasim Al-Abboud",
        Email = "qasim.alabboud@example.com",
        PhoneNumber = "111111111",
        AccountType = "Trainee",
        Password = "mohamed11",
        ConfirmPassword = "mohamed11"
    },
    new RegisterViewModel
    {
        Name = "Sameer Al-Hakeem",
        Email = "sameer.alhakeem@example.com",
        PhoneNumber = "222222222",
        AccountType = "Trainee",
        Password = "mohamed11",
        ConfirmPassword = "mohamed11"
    },
    new RegisterViewModel
    {
        Name = "Haytham Al-Qassim",
        Email = "haytham.alqassim@example.com",
        PhoneNumber = "333333333",
        AccountType = "Trainee",
        Password = "mohamed11",
        ConfirmPassword = "mohamed11"
    },
    new RegisterViewModel
    {
        Name = "Hisham Al-Maari",
        Email = "hisham.almaari@example.com",
        PhoneNumber = "444444444",
        AccountType = "Trainee",
        Password = "mohamed11",
        ConfirmPassword = "mohamed11"
    },
    new RegisterViewModel
    {
        Name = "Rafat Al-Sharif",
        Email = "rafat.alsharif@example.com",
        PhoneNumber = "555555555",
        AccountType = "Trainee",
        Password = "mohamed11",
        ConfirmPassword = "mohamed11"
    },
    new RegisterViewModel
    {
        Name = "Salah Al-Talib",
        Email = "salah.altalib@example.com",
        PhoneNumber = "666666666",
        AccountType = "Trainee",
        Password = "mohamed11",
        ConfirmPassword = "mohamed11"
    },
    new RegisterViewModel
    {
        Name = "Wael Al-Khayat",
        Email = "wael.alkhayat@example.com",
        PhoneNumber = "777777777",
        AccountType = "Trainee",
        Password = "mohamed11",
        ConfirmPassword = "mohamed11"
    },
    new RegisterViewModel
    {
        Name = "Issam Al-Jundi",
        Email = "issam.aljundi@example.com",
        PhoneNumber = "888888888",
        AccountType = "Trainee",
        Password = "mohamed11",
        ConfirmPassword = "mohamed11"
    },
    new RegisterViewModel
    {
        Name = "Saif Al-Zahrani",
        Email = "saif.alzahrani@example.com",
        PhoneNumber = "999999999",
        AccountType = "Trainee",
        Password = "mohamed11",
        ConfirmPassword = "mohamed11"
    },
    new RegisterViewModel
    {
        Name = "Zaki Al-Fahd",
        Email = "zaki.alfahd@example.com",
        PhoneNumber = "123123123",
        AccountType = "Trainee",
        Password = "mohamed11",
        ConfirmPassword = "mohamed11"
    },
    new RegisterViewModel
    {
        Name = "Amin Al-Najjar",
        Email = "amin.alnajjar@example.com",
        PhoneNumber = "456456456",
        AccountType = "Trainee",
        Password = "mohamed11",
        ConfirmPassword = "mohamed11"
    },
    new RegisterViewModel
    {
        Name = "Tariq Al-Hamad",
        Email = "tariq.alhamad@example.com",
        PhoneNumber = "789789789",
        AccountType = "Trainee",
        Password = "mohamed11",
        ConfirmPassword = "mohamed11"
    },
    new RegisterViewModel
    {
        Name = "Nidal Al-Qasimi",
        Email = "nidal.alqasimi@example.com",
        PhoneNumber = "987987987",
        AccountType = "Trainee",
        Password = "mohamed11",
        ConfirmPassword = "mohamed11"
    },
    new RegisterViewModel
    {
        Name = "Rafiq Al-Mazin",
        Email = "rafiq.almazin@example.com",
        PhoneNumber = "654654654",
        AccountType = "Trainee",
        Password = "mohamed11",
        ConfirmPassword = "mohamed11"
    },
    new RegisterViewModel
    {
        Name = "Hamza Al-Saad",
        Email = "hamza.alsaad@example.com",
        PhoneNumber = "321321321",
        AccountType = "Trainee",
        Password = "mohamed11",
        ConfirmPassword = "mohamed11"
    },
    new RegisterViewModel
    {
        Name = "Yasin Al-Maamari",
        Email = "yasin.almaamari@example.com",
        PhoneNumber = "111222333",
        AccountType = "Trainee",
        Password = "mohamed11",
        ConfirmPassword = "mohamed11"
    },
    new RegisterViewModel
    {
        Name = "Hazem Al-Khateeb",
        Email = "hazem.alkhateeb@example.com",
        PhoneNumber = "444555666",
        AccountType = "Trainee",
        Password = "mohamed11",
        ConfirmPassword = "mohamed11"
    },
    new RegisterViewModel
    {
        Name = "Tamer Al-Tahan",
        Email = "tamer.altahan@example.com",
        PhoneNumber = "777888999",
        AccountType = "Trainee",
        Password = "mohamed11",
        ConfirmPassword = "mohamed11"
    },
    new RegisterViewModel
    {
        Name = "Ghassan Al-Rifai",
        Email = "ghassan.alrifai@example.com",
        PhoneNumber = "999888777",
        AccountType = "Trainee",
        Password = "mohamed11",
        ConfirmPassword = "mohamed11"
    },
    new RegisterViewModel
    {
        Name = "Anwar Al-Mahfouz",
        Email = "anwar.almahfouz@example.com",
        PhoneNumber = "555666444",
        AccountType = "Trainee",
        Password = "mohamed11",
        ConfirmPassword = "mohamed11"
    }

};
            foreach (var model in traineeData)
            {
                _userManager.RegisterInBackground(model);
            }
        }
        private static void CreateTrainersForFirstTime()
        {
            var instructors = new RegisterViewModel[]
                        {
                            new RegisterViewModel
                            {
                                Name = "Ahmed Khalid",
                                Email = "ahmed.khalid@example.com",
                                PhoneNumber = "123456789",
                                AccountType = "Trainer",
                                Password = "mohamed11",
                                ConfirmPassword = "mohamed11"
                            }
                            ,
                            new RegisterViewModel
                            {
                                Name = "Tariq Al-Farsi",
                                Email = "tariq.alfarsi@example.com",
                                PhoneNumber = "987654321",
                                AccountType = "Trainer",
                                Password = "mohamed11",
                                ConfirmPassword = "mohamed11"
                            },
                            new RegisterViewModel
                            {
                                Name = "Amir Hamza",
                                Email = "amir.hamza@example.com",
                                PhoneNumber = "555666777",
                                AccountType = "Trainer",
                                Password = "mohamed11",
                                ConfirmPassword = "mohamed11"
                            },
                            new RegisterViewModel
                            {
                                Name = "Kareem Mansoor",
                                Email = "kareem.mansoor@example.com",
                                PhoneNumber = "111222333",
                                AccountType = "Trainer",
                                Password = "mohamed11",
                                ConfirmPassword = "mohamed11"
                            },
                            new RegisterViewModel
                            {
                                Name = "Samir Hassan",
                                Email = "samir.hassan@example.com",
                                PhoneNumber = "999888777",
                                AccountType = "Trainer",
                                Password = "mohamed11",
                                ConfirmPassword = "mohamed11"
                            },
                            new RegisterViewModel
                            {
                                Name = "Ahmed Al-Mansoori",
                                Email = "ahmed.almansoori@example.com",
                                PhoneNumber = "444555666",
                                AccountType = "Trainer",
                                Password = "mohamed11",
                                ConfirmPassword = "mohamed11"
                            },
                            new RegisterViewModel
                            {
                                Name = "Malik Saad",
                                Email = "malik.saad@example.com",
                                PhoneNumber = "777888999",
                                AccountType = "Trainer",
                                Password = "mohamed11",
                                ConfirmPassword = "mohamed11"
                            },
                            new RegisterViewModel
                            {
                                Name = "Omar Abdullah",
                                Email = "omar.abdullah@example.com",
                                PhoneNumber = "333222111",
                                AccountType = "Trainer",
                                Password = "mohamed11",
                                ConfirmPassword = "mohamed11"
                            },
                            new RegisterViewModel
                            {
                                Name = "Adam Al-Ali",
                                Email = "adam.ali@example.com",
                                PhoneNumber = "666555444",
                                AccountType = "Trainer",
                                Password = "mohamed11",
                                ConfirmPassword = "mohamed11"
                            },
                            new RegisterViewModel
                            {
                                Name = "Khaled Al-Hakim",
                                Email = "khaled.alhakim@example.com",
                                PhoneNumber = "123123123",
                                AccountType = "Trainer",
                                Password = "mohamed11",
                                ConfirmPassword = "mohamed11"
                            },
                            new RegisterViewModel
                    {
                        Name = "Zayd Al-Qasimi",
                        Email = "zayd.alqasimi@example.com",
                        PhoneNumber = "111111111",
                        AccountType = "Trainer",
                        Password = "mohamed11",
                        ConfirmPassword = "mohamed11"
                    },
                            new RegisterViewModel
                            {
                                Name = "Bilal Qassem",
                                Email = "bilal.qassem@example.com",
                                PhoneNumber = "222222222",
                                AccountType = "Trainer",
                                Password = "mohamed11",
                                ConfirmPassword = "mohamed11"
                            },
                            new RegisterViewModel
                            {
                                Name = "Karim Suleiman",
                                Email = "karim.suleiman@example.com",
                                PhoneNumber = "333333333",
                                AccountType = "Trainer",
                                Password = "mohamed11",
                                ConfirmPassword = "mohamed11"
                            },
                            new RegisterViewModel
                            {
                                Name = "Youssef Sharif",
                                Email = "youssef.sharif@example.com",
                                PhoneNumber = "444444444",
                                AccountType = "Trainer",
                                Password = "mohamed11",
                                ConfirmPassword = "mohamed11"
                            },
                            new RegisterViewModel
                            {
                                Name = "Rashid Al-Qaderi",
                                Email = "rashid.alqaderi@example.com",
                                PhoneNumber = "555555555",
                                AccountType = "Trainer",
                                Password = "mohamed11",
                                ConfirmPassword = "mohamed11"
                            },
                            new RegisterViewModel
                            {
                                Name = "Hassan Al-Mahdi",
                                Email = "hassan.almahdi@example.com",
                                PhoneNumber = "666666666",
                                AccountType = "Trainer",
                                Password = "mohamed11",
                                ConfirmPassword = "mohamed11"
                            },
                            new RegisterViewModel
                            {
                                Name = "Fadi Rizk",
                                Email = "fadi.rizk@example.com",
                                PhoneNumber = "777777777",
                                AccountType = "Trainer",
                                Password = "mohamed11",
                                ConfirmPassword = "mohamed11"
                            },
                            new RegisterViewModel
                            {
                                Name = "Majid Al-Hassan",
                                Email = "majid.alhassan@example.com",
                                PhoneNumber = "888888888",
                                AccountType = "Trainer",
                                Password = "mohamed11",
                                ConfirmPassword = "mohamed11"
                            },
                            new RegisterViewModel
                            {
                                Name = "Jamal Farid",
                                Email = "jamal.farid@example.com",
                                PhoneNumber = "999999999",
                                AccountType = "Trainer",
                                Password = "mohamed11",
                                ConfirmPassword = "mohamed11"
                            },
                            new RegisterViewModel
    {
        Name = "Ziad Al-Makki",
        Email = "ziad.almakki@example.com",
        PhoneNumber = "1111111111",
        AccountType = "Trainer",
        Password = "mohamed11",
        ConfirmPassword = "mohamed11"
    },
    new RegisterViewModel
    {
        Name = "Salah Al-Din",
        Email = "salah.aldin@example.com",
        PhoneNumber = "2222222222",
        AccountType = "Trainer",
        Password = "mohamed11",
        ConfirmPassword = "mohamed11"
    },
    new RegisterViewModel
    {
        Name = "Idris Al-Sabri",
        Email = "idris.alsabri@example.com",
        PhoneNumber = "3333333333",
        AccountType = "Trainer",
        Password = "mohamed11",
        ConfirmPassword = "mohamed11"
    },
    new RegisterViewModel
    {
        Name = "Raed Al-Abdullah",
        Email = "raed.alabdullah@example.com",
        PhoneNumber = "4444444444",
        AccountType = "Trainer",
        Password = "mohamed11",
        ConfirmPassword = "mohamed11"
    },
    new RegisterViewModel
    {
        Name = "Fahad Al-Hadi",
        Email = "fahad.alhadi@example.com",
        PhoneNumber = "5555555555",
        AccountType = "Trainer",
        Password = "mohamed11",
        ConfirmPassword = "mohamed11"
    },
    new RegisterViewModel
    {
        Name = "Mustafa Al-Mousa",
        Email = "mustafa.almousa@example.com",
        PhoneNumber = "6666666666",
        AccountType = "Trainer",
        Password = "mohamed11",
        ConfirmPassword = "mohamed11"
    },
    new RegisterViewModel
    {
        Name = "Saif Al-Din",
        Email = "saif.aldin@example.com",
        PhoneNumber = "7777777777",
        AccountType = "Trainer",
        Password = "mohamed11",
        ConfirmPassword = "mohamed11"
    },
    new RegisterViewModel
    {
        Name = "Kamil Al-Aziz",
        Email = "kamil.alaziz@example.com",
        PhoneNumber = "8888888888",
        AccountType = "Trainer",
        Password = "mohamed11",
        ConfirmPassword = "mohamed11"
    },
    new RegisterViewModel
    {
        Name = "Hisham Al-Farooq",
        Email = "hisham.alfarooq@example.com",
        PhoneNumber = "9999999999",
        AccountType = "Trainer",
        Password = "mohamed11",
        ConfirmPassword = "mohamed11"
    },
    new RegisterViewModel
    {
        Name = "Nizar Al-Attar",
        Email = "nizar.alattar@example.com",
        PhoneNumber = "1010101010",
        AccountType = "Trainer"  ,
        Password = "mohamed11",
        ConfirmPassword = "mohamed11"
    },
    new RegisterViewModel
    {
        Name = "Walid Al-Masri",
        Email = "walid.almasri@example.com",
        PhoneNumber = "1212121212",
        AccountType = "Trainer",
        Password = "mohamed11",
        ConfirmPassword = "mohamed11"
    }
                                };

            var instructorsMeta = new (string expertise, string description)[]
                  {
            ("Web Development, Mobile App Development", "Ahmed is a seasoned professional specializing in web and mobile app development. With a wealth of experience, he is ready to guide you through the intricacies of creating cutting-edge applications."),
            ("Data Science", "Tariq is a data science guru, passionate about unraveling insights from data. Join his courses to delve into the world of data analysis, machine learning, and data-driven decision-making."),
            ("Cybersecurity, Networking", "Amir is your go-to expert for all things cybersecurity and networking. Learn from him to fortify your digital defenses and understand the intricacies of securing networks."),
            ("Entrepreneurship", "Kareem, a seasoned entrepreneur, shares his experiences and insights to help you navigate the challenging yet rewarding world of entrepreneurship. Learn how to turn your ideas into successful ventures."),
            ("Digital Marketing, Content Marketing, Social Media Marketing", "Samir is a digital marketing maestro, ready to guide you through the dynamic landscape of online marketing. From content creation to social media strategies, he has you covered."),
            ("Personal Finance, Corporate Finance", "Ahmed is your financial guide, offering expertise in personal and corporate finance. Learn how to manage your finances effectively and make informed investment decisions."),
            ("Nutrition, Mental Health", "Malik is passionate about holistic well-being. Join his courses to explore the realms of nutrition and mental health, discovering the keys to a healthier and happier life."),
            ("UX/UI Design, Interior Design", "Omar is a creative design wizard, ready to unleash your artistic potential. Dive into the world of user experience, interface design, and interior aesthetics with his expert guidance."),
            ("English as a Second Language, Public Speaking, Creative Writing", "Adam is your language and communication mentor. Whether you're perfecting your English, honing your public speaking skills, or expressing yourself through creative writing, Adam's courses are the key."),
            ("Renewable Energy, Sustainable Living", "Khaled is a sustainability advocate. Join his courses to explore renewable energy solutions and adopt sustainable living practices for a greener and more eco-friendly lifestyle.")
                 ,
            ("Algebra, Calculus, Statistics", "Zayd is a mathematics enthusiast, ready to guide you through the fascinating world of algebra, calculus, and statistics. Join his courses to master the foundations of mathematical principles."),
            ("Fitness, Strength Training, Cardiovascular Exercise, Yoga", "Bilal is your fitness guru, passionate about helping you achieve your health and wellness goals. From strength training to yoga, he's got the expertise to keep you fit and healthy."),
            ("Science", "Karim is a science aficionado, offering insights into the realms of biology, physics, and chemistry. Dive into the wonders of science with his engaging courses."),
            ("Environment and Sustainability, Renewable Energy, Sustainable Living", "Youssef is an advocate for environmental sustainability. Join his courses to explore renewable energy solutions and adopt sustainable living practices for a greener future."),
            ("Arts and Crafts, Painting, Pottery, Photography", "Rashid is a creative artist, ready to guide you through the world of arts and crafts. From painting to pottery and photography, discover your artistic side with Rashid."),
            ("Science, Biology, Physics, Chemistry", "Hassan is a science enthusiast, offering in-depth knowledge in biology, physics, and chemistry. Explore the wonders of the natural world through his engaging courses."),
            ("Finance", "Fadi is a finance expert, ready to demystify the world of finance. Join his courses to understand the intricacies of financial management and investment strategies."),
            ("History, Philosophy, Literature", "Majid is a humanities scholar, offering insights into history, philosophy, and literature. Explore the rich tapestry of human thought and culture through Majid's thought-provoking courses."),
            ("Arts and Crafts, Painting, Pottery, Photography", "Jamal is a creative artist, specializing in arts and crafts. Join his courses to develop your artistic skills, whether it's painting, pottery, or photography."),
            ("Design, Graphic Design, UX/UI Design, Interior Design", "Ziad is a design maestro, ready to guide you through the principles of graphic design, UX/UI design, and interior design. Unleash your creativity with Ziad's expert instruction.")
            ,
             ("Biology, Physics, Chemistry", "Salah is a science enthusiast, specializing in biology, physics, and chemistry. Join his courses to explore the wonders of the natural world."),
            ("Graphic Design, UX/UI Design, Interior Design", "Idris is a design maestro, offering expertise in graphic design, UX/UI design, and interior aesthetics. Unleash your creativity under his expert guidance."),
            ("Language and Communication", "Raed is your communication guru. Join his courses to enhance your language skills, master public speaking, and explore the art of creative writing."),
            ("Fitness, Strength Training, Cardiovascular Exercise, Yoga", "Fahad is a fitness fanatic, ready to guide you through various workout routines. From strength training to yoga, Fahad has your fitness journey covered."),
            ("Mathematics, Algebra, Calculus, Statistics", "Mustafa is a mathematics wizard, offering expertise in algebra, calculus, and statistics. Join his courses to conquer the world of numbers and mathematical concepts."),
            ("History, Philosophy, Literature", "Saif is a humanities scholar, passionate about history, philosophy, and literature. Explore the rich tapestry of human thought and culture with Saif."),
            ("Photography", "Kamil is your photography mentor. Learn the art of capturing moments and creating stunning visual stories through Kamil's photography courses."),
            ("Environment and Sustainability, Renewable Energy, Sustainable Living", "Hisham is a sustainability advocate. Join his courses to explore environmental issues, renewable energy solutions, and adopt sustainable living practices."),
            ("Language and Communication", "Nizar is your language and communication mentor. Join his courses to enhance your language skills, master public speaking, and explore the art of creative writing."),
            ("Arts and Crafts, Painting, Pottery", "Walid is an arts and crafts enthusiast, specializing in painting and pottery. Unleash your artistic potential and explore the world of visual arts with Walid.")

                  };

            for (int i = 0;i<30;i++)
            {
                _userManager.RegisterInBackground(instructors[i], instructorsMeta[i].description, instructorsMeta[i].expertise);
            }
        }
        private static void CreateCategoriesForFirstTime()
        {
            Dictionary<string, string> categoryHierarchy = new Dictionary<string, string>
        {
            { "Technology", null },
            { "Programming", "Technology" },
            { "Web Development", "Programming" },
            { "Mobile App Development", "Programming" },
            { "Data Science", "Programming" },
            { "Cybersecurity", "Technology" },
            { "Networking", "Technology" },
            { "Business", null },
            { "Marketing", "Business" },
            { "Digital Marketing", "Marketing" },
            { "Content Marketing", "Marketing" },
            { "Social Media Marketing", "Marketing" },
            { "Entrepreneurship", "Business" },
            { "Finance", "Business" },
            { "Personal Finance", "Finance" },
            { "Corporate Finance", "Finance" },
            { "Health and Wellness", null },
            { "Fitness", "Health and Wellness" },
            { "Strength Training", "Fitness" },
            { "Cardiovascular Exercise", "Fitness" },
            { "Yoga", "Fitness" },
            { "Nutrition", "Health and Wellness" },
            { "Mental Health", "Health and Wellness" },
            { "Design", null },
            { "Graphic Design", "Design" },
            { "UX/UI Design", "Design" },
            { "Interior Design", "Design" },
            { "Language and Communication", null },
            { "English as a Second Language", "Language and Communication" },
            { "Public Speaking", "Language and Communication" },
            { "Creative Writing", "Language and Communication" },
            { "Science", null },
            { "Biology", "Science" },
            { "Physics", "Science" },
            { "Chemistry", "Science" },
            { "Environment and Sustainability", null },
            { "Renewable Energy", "Environment and Sustainability" },
            { "Sustainable Living", "Environment and Sustainability" },
            { "Arts and Crafts", null },
            { "Painting", "Arts and Crafts" },
            { "Pottery", "Arts and Crafts" },
            { "Photography", "Arts and Crafts" },
            { "Mathematics", null },
            { "Algebra", "Mathematics" },
            { "Calculus", "Mathematics" },
            { "Statistics", "Mathematics" },
            { "Humanities", null },
            { "History", "Humanities" },
            { "Philosophy", "Humanities" },
            { "Literature", "Humanities" }
        };
            foreach (var item in categoryHierarchy)
            {
                Category categ = new Category()
                {
                    Name = item.Key,
                    ParentId = categoryService.GetCategoryByName(item.Value)?.Id
                };
                categoryService.Add(categ);
            }
        }

    }
}