// Angular imports
import {of} from 'rxjs';
import {HttpRequest, HttpResponse} from '@angular/common/http';
// Local imports
import * as user from '../../assets/mock-data/users.json';
import * as resolvedHW from '../../assets/mock-data/resolved_hw.json';

import * as course from '../../assets/mock-data/courses.json';
import * as organization from '../../assets/mock-data/organizations.json';

import * as post from '../../assets/mock-data/posts.json';
import * as hw from '../../assets/mock-data/hw.json';
import * as comment from '../../assets/mock-data/comments.json';


let users: any[] = (user as any).default;

let courses: any[] = (course as any).default;
let organizations: any[] = (organization as any).default;

let posts: any[] = (post as any).default;
let homework: any[] = (hw as any).default;
let resolvedHw: any[] = (resolvedHW as any).default;
let comments: any[] = (comment as any).default;

const getUser = (authHeader: String) => {
  const stringId = authHeader.replace('Bearer ', '');
  const id = Number(stringId);

  return users.find(user => user.id === id);
}


const login = (request: HttpRequest<any>) => {
    const user = users.find(u => u.userName === request.body.email);
    const token = user?.id;
    if (!user) {
      return of(new HttpResponse({
        status: 404
      }));
    }

    const result = {
        user,
        token,
    };
    return of(new HttpResponse({
      status: 200, body: result
    }));
};

const register = (request: HttpRequest<any>) => {
  const userName = request.body.email;
  const user = {
    userName: userName,
    id: Date.now(),
    name: userName,
    roleId: request.body.roleId,
  };
  users.push(user);

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

const getOrganizations = (request: HttpRequest<any>) => {
  return of(new HttpResponse({
    status: 200, body: organizations
  }));
};

const getOrganization = (request: HttpRequest<any>) => {
  const requestUrl = new URL(request.url);
  const pathname = requestUrl.pathname;
  const attributes = pathname.split("/");
  const facultyName = attributes[attributes.length - 1];
  
  const organization = organizations.find(organization => organization.facultyName === facultyName);
  return of(new HttpResponse({
    status: 200, body: organization
  }));
 
};

const resolveHw = (request: HttpRequest<any>) => {
  const hwContent = {
    id: Date.now(),
    hwId: request.body?.hwId,
    userId: request.body?.userId,
    resolveFile: request.body?.file,
  };
  resolvedHw.push(hwContent);
  return of(new HttpResponse({
    status: 200
  }));

};

const createPost = (request: HttpRequest<any>) => {
  const bo = request.body?.entries();
  const authHeader = request.headers.get('authorization');
  const user = getUser(authHeader || '');

  if (!user) {
    return of(new HttpResponse({
      status: 404,
    }));
  }

  const post = {
    userId: user.id,
    userName: user.userName,
    date: new Date().toDateString(),
    id: Date.now(),
  };
  for (let [key, value] of bo) {
    post[key] = value;
  }

  posts.push(post);

  return of(new HttpResponse({
    status: 200,
  }));
};

const createHw = (request: HttpRequest<any>) => {
  const user = JSON.parse(localStorage.getItem('user') || '{}');
  const bo = request.body?.entries();

  if (!user) {
    return of(new HttpResponse({
      status: 404,
    }));
  }

  const hw = {
    userId: user.id,
    userName: user.userName,
    createdDate: new Date().toDateString(),
    id: Date.now(),
  };
  for (let [key, value] of bo) {
    hw[key] = value;
  }

  homework.push(hw);

  return of(new HttpResponse({
    status: 200,
  }));
};

const updatePost = (request: HttpRequest<any>) => {
  return of(new HttpResponse({
    status: 200,
  }));
};

const getPosts = (request: HttpRequest<any>) => {
  return of(new HttpResponse({
    status: 200, body: posts
  }));
}

const getUsers = (request: HttpRequest<any>) => {
  return of(new HttpResponse({
    status: 200, body: users
  }));
}

const getHw = (request: HttpRequest<any>) => {
  const user = JSON.parse(localStorage.getItem('user') || '{}');

  if (!user) {
    return of(new HttpResponse({
      status: 404,
    }));
  }

  homework.map(hw => {
    const resolved = resolvedHw.find(homework => homework.userId === user.id && hw.id === homework.hwId);
    hw.resolved = !!resolved;
    hw.resolveFile = resolved?.resolveFile;
  });
  return of(new HttpResponse({
    status: 200, body: homework,
  }));
}

const getPost = (request: HttpRequest<any>) => {
  const requestUrl = new URL(request.url);
  const pathname = requestUrl.pathname;
  const attributes = pathname.split("/");
  const id = Number(attributes[attributes.length - 1]);
  
  const post = posts.find(post => post.id === id);
  console.log(posts)
  return of(new HttpResponse({
    status: 200, body: post
  }));
}

const getPostComments = (request: HttpRequest<any>) => {
  const requestUrl = new URL(request.url);
  const pathname = requestUrl.pathname;
  const attributes = pathname.split("/");
  const postId = attributes[attributes.length - 2];
  const comms = comments.filter(c => c.postId == postId);
  return of(new HttpResponse({
    status: 200, body: comms
  }));
}

const postUser = (request: HttpRequest<any>) => {
  return of(new HttpResponse({
    status: 200,
  }));
}


export const selectHandler = (request: HttpRequest<any>) => {
  const requestUrl = new URL(request.url);
  const getOneRegexp: RegExp = new RegExp(`/login`);
  const pathname = requestUrl.pathname;
  switch (request.method) {
    case 'GET':

      if (pathname === "/Homework") {
        return getHw;
      }
      if (pathname === "/Courses" || pathname.startsWith("/Courses/Users")) {
         return getCourses;
      }
      if(pathname.startsWith("/Courses")) {
        return getCourse;
      }
      if(pathname === "/Organizations" || pathname.startsWith("/Organizations/Users")) {
        return getOrganizations;
      }
      if(pathname.startsWith("/Organizations")) {
        return getOrganization;
      }

        // if (pathname == "/Posts") {
        //   return getPosts;
        // }

        // if (pathname.startsWith("/Posts") && pathname.endsWith("/Comments")) {
        //   return getPostComments
        // }

        // if (pathname.startsWith("/Posts")) {
        //   return getPost
        // }

        // if (pathname == '/Users') {
        //   return getUsers;
        // }


        return null;
    case 'POST':
        // if (pathname === "/api/Authentication/login") {
        //     return login;
        // }
        
        // if (pathname === "/api/Authentication/register") {
        //     return register;
        // }

        // if (pathname == "/Posts") {
        //   return createPost
        // }

        if (pathname.startsWith("/Users")) {
          return postUser;
        }

        if (pathname == "/Upload") {
          return postUser;
        }

        if (pathname.endsWith('resolve')) {
          return resolveHw;
        }

        if (pathname === "/Homework") {
          return createHw;
        }

        return null;
    case 'PUT':
      // if (pathname.startsWith("/Posts")) {
      //   return updatePost;
      // }
      return null;
    case 'DELETE':
      return null;
    default:
      return null;
  }
};