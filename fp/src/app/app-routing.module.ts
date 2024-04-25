import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TasklistComponent } from './tasklist/tasklist.component';
import { taskcreateComponent } from './taskcreate/taskcreate.component';
import { taskediteComponent } from './taskedit/taskedit.component';
import { LoginComponent } from './login/login.component';


const routes: Routes = [
  {path:'tlist',component:TasklistComponent},
  {path:'create',component:taskcreateComponent},
  {path:'edit/:taskId',component:taskediteComponent},
  {path: 'login',component:LoginComponent},
  {path:'',redirectTo:'login',pathMatch:"full"}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
