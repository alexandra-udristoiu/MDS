import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CreatePostComponent } from './create-post/create-post.component';
import { EditPostComponent } from './edit-post/edit-post.component';
import { AuthGuard } from './guards/auth.guard';
import { CheckGuard } from './guards/check.guard';
import { LoginComponent } from './login/login.component';
import { PostPageComponent } from './post-page/post-page.component';
import { PostsComponent } from './posts/posts.component';
import { RegisterComponent } from './register/register.component';

const routes: Routes = [
  { path: 'login', component: LoginComponent, canActivate: [CheckGuard] },
  { path: 'register', component: RegisterComponent, canActivate: [CheckGuard] },
  { path: 'posts', component: PostsComponent, canActivate: [AuthGuard]},
  { path: 'posts/:postId', component: PostPageComponent, canActivate: [AuthGuard]},
  { path: "create-post", component: CreatePostComponent, canActivate: [AuthGuard]},
  { path: "edit-post/:postId", component: EditPostComponent, canActivate: [AuthGuard]}
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
