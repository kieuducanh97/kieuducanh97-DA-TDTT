using JobFinder.Models;

namespace JobFinder.Data;

public static class DataInitializer
{
    public static void Initialize(JobFinderDbContext context, bool forceReset = false)
    {
        context.Database.EnsureCreated();

        if (!forceReset && context.Jobs.Any() && context.Users.Any())
        {
            return;
        }

        if (context.Jobs.Any())
        {
            context.Jobs.RemoveRange(context.Jobs);
        }

        if (context.Users.Any())
        {
            context.Users.RemoveRange(context.Users);
        }

        context.SaveChanges();

        var users = new List<User>
        {
            new()
            {
                Username = "admin",
                FullName = "Quản trị viên JobFinder",
                Role = "Admin",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("Admin@123")
            },
            new()
            {
                Username = "ungvien",
                FullName = "Nguyễn Minh Anh",
                Role = "User",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("User@123")
            }
        };

        var jobs = new List<Job>
        {
            CreateJob("Lập trình viên .NET", "TechViet Solutions", "TP. Hồ Chí Minh", "25 - 35 triệu", "Toàn thời gian", 2, "2+ năm", "Nhân viên", true, "TS",
                "Phát triển hệ thống quản lý tuyển dụng bằng ASP.NET Core, tối ưu hiệu năng API và phối hợp cùng QA để đảm bảo chất lượng phát hành.",
                "Phân tích yêu cầu nghiệp vụ|Xây dựng API ASP.NET Core|Tối ưu truy vấn Entity Framework|Viết unit test cho module chính|Phối hợp DevOps triển khai",
                "Có kinh nghiệm C#/.NET Core|Nắm tốt SQL và LINQ|Biết làm việc với Git, CI/CD|Có tư duy giải quyết vấn đề|Ưu tiên từng làm SaaS"),
            CreateJob("Kỹ sư Frontend React", "Nova Digital", "Hà Nội", "22 - 32 triệu", "Toàn thời gian", 1, "2+ năm", "Nhân viên", true, "ND",
                "Thiết kế giao diện web tuyển dụng hiện đại, tối ưu trải nghiệm người dùng và tích hợp với backend thông qua REST API.",
                "Xây dựng UI bằng React|Tối ưu hiệu năng và SEO|Làm việc với Figma và backend|Viết component tái sử dụng|Đảm bảo responsive",
                "Thành thạo React và TypeScript|Hiểu HTML/CSS/JS hiện đại|Kinh nghiệm state management|Biết test frontend là lợi thế|Tinh thần làm việc nhóm"),
            CreateJob("Chuyên viên DevOps", "CloudHub Vietnam", "Đà Nẵng", "28 - 40 triệu", "Toàn thời gian", 3, "3+ năm", "Senior", true, "CH",
                "Vận hành hạ tầng cloud, tự động hóa quy trình triển khai và giám sát hệ thống cho các sản phẩm tuyển dụng quy mô lớn.",
                "Xây dựng pipeline CI/CD|Quản trị Docker và Kubernetes|Giám sát log, metric, alert|Tối ưu chi phí cloud|Hỗ trợ release production",
                "Có kinh nghiệm AWS/Azure/GCP|Thành thạo Docker, Kubernetes|Sử dụng được Terraform|Hiểu Linux networking|Kinh nghiệm bảo mật cơ bản"),
            CreateJob("Chuyên viên Phân tích nghiệp vụ", "Bright HR", "TP. Hồ Chí Minh", "18 - 25 triệu", "Toàn thời gian", 4, "1+ năm", "Nhân viên", false, "BH",
                "Làm việc với khách hàng doanh nghiệp để thu thập yêu cầu, mô hình hóa quy trình tuyển dụng và phối hợp đội phát triển triển khai giải pháp.",
                "Khảo sát và ghi nhận yêu cầu|Viết tài liệu BRD, SRS|Phối hợp UAT với khách hàng|Theo dõi tiến độ tính năng|Đề xuất cải tiến quy trình",
                "Có kỹ năng giao tiếp tốt|Tư duy phân tích rõ ràng|Biết viết tài liệu nghiệp vụ|Có kinh nghiệm phần mềm HR là lợi thế|Chủ động học hỏi"),
            CreateJob("UI/UX Designer", "Pixel Studio", "Hà Nội", "16 - 24 triệu", "Toàn thời gian", 2, "2+ năm", "Nhân viên", true, "PS",
                "Thiết kế trải nghiệm người dùng cho web tuyển dụng, xây dựng design system và phối hợp cùng frontend để đảm bảo chất lượng giao diện.",
                "Nghiên cứu hành vi người dùng|Thiết kế wireframe, prototype|Xây dựng thư viện component|Kiểm thử usability|Bàn giao thiết kế cho dev",
                "Sử dụng tốt Figma|Hiểu nguyên tắc UI/UX|Có portfolio web/app|Tư duy hệ thống tốt|Biết animation là lợi thế"),
            CreateJob("Kỹ sư Kiểm thử phần mềm", "Vina Quality", "Cần Thơ", "15 - 22 triệu", "Toàn thời gian", 5, "1+ năm", "Nhân viên", false, "VQ",
                "Xây dựng kế hoạch kiểm thử, đảm bảo chất lượng tính năng tuyển dụng trước khi phát hành tới người dùng cuối.",
                "Viết test case, checklist|Kiểm thử chức năng và giao diện|Log bug rõ ràng|Phối hợp dev tái hiện lỗi|Hỗ trợ regression test",
                "Có kinh nghiệm test web/app|Tỉ mỉ và logic|Biết SQL cơ bản|Ưu tiên biết automation test|Khả năng viết tài liệu tốt"),
            CreateJob("Lập trình viên Mobile Flutter", "Mobix Labs", "TP. Hồ Chí Minh", "20 - 30 triệu", "Toàn thời gian", 2, "2+ năm", "Nhân viên", true, "ML",
                "Phát triển ứng dụng di động hỗ trợ ứng viên tìm việc, lưu việc và nhận thông báo tuyển dụng theo thời gian thực.",
                "Xây dựng app Flutter đa nền tảng|Tích hợp API và thông báo đẩy|Tối ưu hiệu suất màn hình|Phối hợp backend xử lý dữ liệu|Bảo trì ứng dụng sau phát hành",
                "Thành thạo Dart/Flutter|Có ứng dụng đã lên store|Hiểu state management|Biết Firebase là lợi thế|Khả năng đọc tài liệu tiếng Anh"),
            CreateJob("Data Engineer", "Insight Works", "Hà Nội", "30 - 42 triệu", "Toàn thời gian", 3, "3+ năm", "Senior", true, "IW",
                "Xây dựng pipeline dữ liệu phục vụ phân tích thị trường lao động, báo cáo và đề xuất công việc phù hợp cho ứng viên.",
                "Thiết kế data pipeline|Xử lý ETL dữ liệu lớn|Tối ưu kho dữ liệu|Làm việc với BI team|Đảm bảo chất lượng dữ liệu",
                "Thành thạo SQL/Python|Có kinh nghiệm Airflow hoặc tương đương|Biết data warehouse|Hiểu mô hình dữ liệu|Kinh nghiệm cloud data stack"),
            CreateJob("Chuyên viên Marketing Tuyển dụng", "Talent Bridge", "Đà Nẵng", "14 - 20 triệu", "Toàn thời gian", 6, "1+ năm", "Nhân viên", false, "TB",
                "Phát triển chiến dịch nội dung và quảng bá tin tuyển dụng giúp doanh nghiệp tiếp cận đúng ứng viên mục tiêu.",
                "Lập kế hoạch content tuyển dụng|Quản lý kênh social và email|Theo dõi hiệu quả chiến dịch|Phối hợp thiết kế nội dung|Báo cáo số liệu định kỳ",
                "Có kinh nghiệm digital marketing|Viết nội dung tốt|Biết chạy quảng cáo là lợi thế|Tư duy phân tích số liệu|Chủ động và sáng tạo"),
            CreateJob("Nhân viên Chăm sóc khách hàng", "CareerCare", "TP. Hồ Chí Minh", "10 - 15 triệu", "Toàn thời gian", 4, "Dưới 1 năm", "Junior", false, "CC",
                "Hỗ trợ doanh nghiệp và ứng viên trong quá trình đăng tuyển, tạo hồ sơ và xử lý các yêu cầu phát sinh trên nền tảng.",
                "Tiếp nhận và phản hồi yêu cầu|Hướng dẫn khách hàng sử dụng hệ thống|Phối hợp kỹ thuật xử lý sự cố|Theo dõi mức độ hài lòng|Cập nhật FAQ nội bộ",
                "Giao tiếp tốt qua điện thoại/email|Kiên nhẫn, trách nhiệm|Biết sử dụng phần mềm văn phòng|Ưu tiên có kinh nghiệm CSKH|Làm việc theo ca linh hoạt"),
            CreateJob("Backend Node.js Developer", "Skysoft", "Hải Phòng", "20 - 28 triệu", "Toàn thời gian", 2, "2+ năm", "Nhân viên", true, "SS",
                "Phát triển dịch vụ backend cho hệ thống gợi ý việc làm, tích hợp dữ liệu từ nhiều nguồn và đảm bảo độ ổn định cao.",
                "Thiết kế API Node.js|Tối ưu hiệu năng dịch vụ|Làm việc với MongoDB/PostgreSQL|Viết tài liệu kỹ thuật|Hỗ trợ giám sát hệ thống",
                "Có kinh nghiệm Node.js/Express|Hiểu RESTful API|Biết thiết kế database|Từng dùng message queue là lợi thế|Chịu được áp lực tiến độ"),
            CreateJob("Product Owner", "FutureWorks", "Hà Nội", "35 - 50 triệu", "Toàn thời gian", 1, "4+ năm", "Manager", true, "FW",
                "Định hướng sản phẩm nền tảng tuyển dụng, ưu tiên backlog và đảm bảo sản phẩm giải quyết đúng nhu cầu thị trường.",
                "Quản lý backlog sản phẩm|Làm việc với stakeholder|Xác định KPI và roadmap|Theo dõi outcome của tính năng|Hỗ trợ đội delivery",
                "Có kinh nghiệm Product Owner|Hiểu Agile/Scrum|Kỹ năng giao tiếp và ưu tiên tốt|Tư duy sản phẩm mạnh|Ưu tiên từng làm HR Tech"),
            CreateJob("Kỹ sư Bảo mật ứng dụng", "SecureByte", "TP. Hồ Chí Minh", "32 - 45 triệu", "Toàn thời gian", 2, "3+ năm", "Senior", true, "SB",
                "Đánh giá lỗ hổng bảo mật, tăng cường an toàn cho tài khoản người dùng và luồng dữ liệu tuyển dụng quan trọng.",
                "Thực hiện security review|Kiểm tra OWASP Top 10|Phối hợp fix lỗ hổng với dev|Xây dựng guideline bảo mật|Hỗ trợ kiểm thử xâm nhập",
                "Hiểu sâu bảo mật web|Có kinh nghiệm với OWASP/ZAP/Burp|Biết secure coding|Từng làm SAST/DAST là lợi thế|Kỹ năng phân tích tốt"),
            CreateJob("Chuyên viên Tuyển dụng IT", "Prime HR", "Hà Nội", "15 - 23 triệu", "Toàn thời gian", 3, "1+ năm", "Nhân viên", false, "PH",
                "Tìm kiếm, sàng lọc và kết nối ứng viên công nghệ cho các vị trí từ fresher tới quản lý cấp trung.",
                "Đăng tin và sourcing ứng viên|Sàng lọc CV, phỏng vấn sơ bộ|Điều phối lịch phỏng vấn|Chăm sóc ứng viên trong suốt quy trình|Theo dõi hiệu quả tuyển dụng",
                "Có kinh nghiệm tuyển dụng IT|Kỹ năng giao tiếp tốt|Biết sử dụng LinkedIn và job board|Có khả năng đánh giá hồ sơ kỹ thuật cơ bản|Yêu thích làm việc với con người"),
            CreateJob("Thực tập sinh Phân tích dữ liệu", "NextData", "TP. Hồ Chí Minh", "5 - 8 triệu", "Bán thời gian", 7, "Sinh viên năm cuối", "Intern", true, "NX",
                "Hỗ trợ làm sạch dữ liệu, dựng dashboard và phân tích xu hướng tuyển dụng cho các báo cáo nội bộ.",
                "Chuẩn hóa dữ liệu từ nhiều nguồn|Làm dashboard cơ bản|Hỗ trợ viết báo cáo phân tích|Làm việc với mentor hàng tuần|Học quy trình dữ liệu thực tế",
                "Biết Excel/SQL cơ bản|Ưu tiên biết Power BI|Tư duy logic và cẩn thận|Có thể làm tối thiểu 24 giờ/tuần|Tinh thần học hỏi tốt")
        };

        context.Users.AddRange(users);
        context.Jobs.AddRange(jobs);
        context.SaveChanges();
    }

    private static Job CreateJob(
        string title,
        string company,
        string location,
        string salary,
        string type,
        int postedDaysAgo,
        string experience,
        string level,
        bool isRemote,
        string logo,
        string description,
        string responsibilities,
        string requirements)
    {
        return new Job
        {
            Title = title,
            Company = company,
            Location = location,
            Salary = salary,
            Type = type,
            PostedDate = DateTime.Today.AddDays(-postedDaysAgo),
            Deadline = DateTime.Today.AddDays(25 - postedDaysAgo),
            Experience = experience,
            Level = level,
            IsRemote = isRemote,
            CompanyLogoUrl = logo,
            Description = description,
            Responsibilities = responsibilities,
            Requirements = requirements
        };
    }
}
