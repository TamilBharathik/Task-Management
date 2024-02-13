import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Task } from './task';

@Injectable({
  providedIn: 'root'
})
export class TaskserviceService {

  baseApiUrl:string="https://localhost:7203";

  baseUrl:string="https://localhost:7203/api/tasks";

  apiURL:string="https://localhost:7203/api/admin/login";

  constructor(private http:HttpClient) { }

  getAllTasks():Observable<Task[]>
  {
     return this.http.get<Task[]>(this.baseApiUrl+'/api/tasks');
  }

  addTask(addTaskRequest:Task):Observable<Task[]>
  {
    addTaskRequest.taskId='00000000-0000-0000-0000-000000000000';
    return this.http.post<Task[]>(this.baseApiUrl+'/api/tasks/',addTaskRequest);
  }

  getTaskById(taskId:string):Observable<Task>
  {
    return this.http.get<Task>(this.baseApiUrl+'/api/tasks/'+taskId);

  }

  updateTaskDetails(taskId: string, updateTaskDet: Task): Observable<Task> {
    return this.http.put<Task>(this.baseApiUrl+'/api/tasks/'+taskId, updateTaskDet);
  }
  

  deleteTask(taskId:string):Observable<Task>
  {
    return this.http.delete<Task>(this.baseApiUrl+'/api/tasks/'+taskId);
  }

  getDetails(id:string):Observable<Task>{
    const url=`${this.baseUrl}/${id}}`;
    return this.http.get<Task>(url);
  }

  login(Username:string,Password:string) : Observable<Task>
  {
    return this.http.post<any>(`${this.baseApiUrl}/api/admin/login`, { Username, Password });
  }

  
}