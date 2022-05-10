import { Component, OnInit } from '@angular/core';
import { Course } from '../_models/courses';
import { CourseService } from '../_services/course.service';



@Component({
  selector: 'app-courses',
  templateUrl: './courses.component.html',
  styleUrls: ['./courses.component.css']
})
export class CoursesComponent implements OnInit {

  courses: Course[] = [];
  selectedCourse?: Course;

  constructor(private courseService: CourseService) { }

  ngOnInit(): void {
    this.getCourse();
  }
  getCourse() {
    this.courseService.getCourses()
      .subscribe(courses => this.courses = courses);
  }

  onSelect(course: Course)
  {
    this.selectedCourse = course;
    
  }

}
