// Angular imports
import {of} from 'rxjs';
import {HttpRequest, HttpResponse} from '@angular/common/http';
// Local imports
import * as user from '../../assets/mock-data/users.json';
import * as course from '../../assets/mock-data/courses.json';

import {User} from '../_models/user';


let users: any[] = (user as any).default;
let courses: any[] = (course as any).default;


const login = (request: HttpRequest<any>) => {
    const user = users[0];
    const token = "token";
    const result = {
        user,
        token,
    };
    return of(new HttpResponse({
      status: 200, body: result
    }));
};

const register = (request: HttpRequest<any>) => {
    return of(new HttpResponse({
      status: 200,
    }));
};

const getCourses = (request: HttpRequest<any>) => {
  return of(new HttpResponse({
    status: 200, body:courses
  }));
};

const getCourse = (request: HttpRequest<any>) => {
  const requestUrl = new URL(request.url);
  const pathname = requestUrl.pathname;
  const attributes = pathname.split("/");
  const name = attributes[attributes.length - 1];
  
  const course = courses.find(course => course.name ===name);
  return of(new HttpResponse({
    status: 200, body: course
  }));
 
};


export const selectHandler = (request: HttpRequest<any>) => {
  const requestUrl = new URL(request.url);
  const getOneRegexp: RegExp = new RegExp(`/login`);
  const pathname = requestUrl.pathname;
  switch (request.method) {
    case 'GET':
      if (pathname === "/Courses") {
        return getCourses;
      }
      if(pathname.startsWith("/Courses")) {
        return getCourse;
      }
        return null;
    case 'POST':
        if (pathname === "/api/Authentication/login") {
            return login;
        }
        
        if (pathname === "/api/Authentication/register") {
            return register;
        }

        return null;
    case 'PUT':
      return null;
    case 'DELETE':
      return null;
    default:
      return null;
  }
};