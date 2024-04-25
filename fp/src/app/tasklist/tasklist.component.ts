import { Component, OnInit, ViewChild } from '@angular/core';
import { TaskserviceService } from '../taskservice.service';
import { Task } from '../task';
import { ActivatedRoute, Router } from '@angular/router';
import { taskediteComponent } from '../taskedit/taskedit.component';
import { PropertyRead } from '@angular/compiler';




@Component({
  selector: 'app-tasklist',
  templateUrl: './tasklist.component.html',
  styleUrl: './tasklist.component.css'
 
})
export class TasklistComponent implements OnInit{
  

  tasks:Task[]=[];

  filteredTasks: Task[] = [];
  searchQuery: string = '';



  constructor(private taskService:TaskserviceService, private router: Router){

  }ngOnInit(): void {
    this.taskService.getAllTasks()
    .subscribe({
      next:(tasks)=>
      {
        this.tasks=tasks;
        this.filteredTasks = tasks;
      },
      error:(response)=>
      {
        console.log(response);
      }
      
    });

  }

  
  deleteTasks(taskId:string)
  {
    this.taskService.deleteTask(taskId)
    .subscribe({
      next:(response)=>
      {
        this.router.navigate(['tlist']);
      },
      error:(response)=>
      {
        console.log(response);
      }
    });
  }


  performSearch() {
    this.filteredTasks = this.tasks.filter(task =>
      task.title.toLowerCase().includes(this.searchQuery.toLowerCase())
    );
    }

    // taskMatchesSearch(task: Task): boolean {
    //   return task.title.toLowerCase().includes(this.searchQuery.toLowerCase());
    // }
    
  }


/*   patch(dt: any){
    this.taskEdit.editDetails.title = dt.title;
    const value = dt;
    

  } */

  // redirectToUrl(task: Task): void {
  //   if (task && task.attachment) {
  //     this.router.navigate(['/url', task.attachment]);
  //   } else {
  //     console.error('Invalid URL or task:', task);
  //   }
  // }


