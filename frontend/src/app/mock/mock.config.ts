// Angular imports
import {of} from 'rxjs';
import {HttpRequest, HttpResponse} from '@angular/common/http';
// Local imports
import * as user from '../../assets/mock-data/users.json';
import * as post from '../../assets/mock-data/posts.json';
import * as comment from '../../assets/mock-data/comments.json';


import {User} from '../_models/user';

let users: any[] = (user as any).default;
let posts: any[] = (post as any).default;
let comments: any[] = (comment as any).default;


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

const createPost = (request: HttpRequest<any>) => {
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


export const selectHandler = (request: HttpRequest<any>) => {
  const requestUrl = new URL(request.url);
  const getOneRegexp: RegExp = new RegExp(`/login`);
  const pathname = requestUrl.pathname;
  switch (request.method) {
    case 'GET':
        if (pathname == "/Posts") {
          return getPosts;
        }

        if (pathname.startsWith("/Posts") && pathname.endsWith("/Comments")) {
          return getPostComments
        }

        if (pathname.startsWith("/Posts")) {
          return getPost
        }

        return null;
    case 'POST':
        if (pathname === "/api/Authentication/login") {
            return login;
        }
        
        if (pathname === "/api/Authentication/register") {
            return register;
        }

        if (pathname == "/Posts") {
          return createPost
        }

        return null;
    case 'PUT':
      if (pathname.startsWith("/Posts")) {
        return updatePost;
      }
      return null;
    case 'DELETE':
      return null;
    default:
      return null;
  }
};