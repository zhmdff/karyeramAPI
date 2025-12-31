namespace KaryeramAPI.Enums
{
    public class Enums
    {
        public enum ApplicationStatus { Pending, Reviewed, Interview, Offered, Rejected }
        public enum EducationLevel { NoEducation, Secondary, IncompleteHigher, Higher, Academic }
        public enum ExperienceLevel { NoExperience, LessThanOneYear, OneToThreeYears, ThreeToFiveYears, MoreThanFiveYears }
        public enum JobType { FullTime, PartTime, Internship, Freelance }
        public enum UserRole { Admin, JobSeeker, Employer, Guest }
    }
}
