import { Component, OnInit } from '@angular/core';
import { TaskserviceService } from '../taskservice.service';
import { Router } from '@angular/router';
import {Task } from '../task';
import { MessageService } from 'primeng/api';
interface City {
  priority: string;
}
@Component({
  selector: 'app-taskcreate',
  templateUrl: './taskcreate.component.html',
  styleUrl: './taskcreate.component.css',
  providers: [MessageService]
})
export class taskcreateComponent implements OnInit{
  cities: City[] | undefined;
  formSubmitted = false;

  selectedCity: City | undefined;
  addTaskRequest:Task={
    taskId: '',
    title: '',
    description: '',
    dueDate: new Date(),
    priority: '',
    comments: '',
    status: '',
    attachment: ''
  };

  constructor(private taskService:TaskserviceService,private router:Router,private messageService: MessageService){}
  showBottomCenter() {
    // Call TaskService method here if needed
    this.messageService.add({ severity: 'success', summary: 'Success', detail: 'Task added Successfully' });
  }
  ngOnInit(): void {}

  createTask()
  {
    this.taskService.addTask(this.addTaskRequest)
    .subscribe({
      next:(task)=>
      {
        this.router.navigate(['tlist']);
        console.log(task);
      },
      error:(response)=>
      {
        console.log(response);
      }
    })
    this.cities = [
      { priority: 'High' },
      { priority: 'Medium'},
      { priority: 'Low' },
  ];
  }

  onSubmit(): void {
    this.formSubmitted = true;
  }

}







// createTask()
// {
//   this.taskService.addTask(this.addTaskRequest)
//   .subscribe({
//     next:(task)=>
//     {
//       this.router.navigate(['tlist']);
//       console.log(task);
//     },
//     error:(response)=>
//     {
//       console.log(response);
//     }
//   })
//   this.cities = [
//     { priority: 'High' },
//     { priority: 'Medium'},
//     { priority: 'Low' },
// ];
// }
