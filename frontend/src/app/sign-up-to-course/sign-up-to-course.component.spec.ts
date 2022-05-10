import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SignUpToCourseComponent } from './sign-up-to-course.component';

describe('SignUpToCourseComponent', () => {
  let component: SignUpToCourseComponent;
  let fixture: ComponentFixture<SignUpToCourseComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SignUpToCourseComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SignUpToCourseComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
