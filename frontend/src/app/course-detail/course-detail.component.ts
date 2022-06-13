import { Component, OnInit, Input } from '@angular/core';
import { Course } from '../_models/courses';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { CourseService } from '../_services/course.service';
import { AuthenticationService } from '../_services/authentication.service';

@Component({
  selector: 'app-course-detail',
  templateUrl: './course-detail.component.html',
  styleUrls: ['./course-detail.component.css']
})
export class CourseDetailComponent implements OnInit {

  @Input() course?: Course;
  constructor(
    private route: ActivatedRoute, 
    private courseService: CourseService, 
    private location: Location,
    public authService: AuthenticationService,
  ) { }

  ngOnInit(): void {
    this.getOrganization();
  }
  getOrganization() : void{
    const name = String(this.route.snapshot.paramMap.get('name'));
    this.courseService.getCourse(name)
      .subscribe(course => this.course = course);
  }
}
