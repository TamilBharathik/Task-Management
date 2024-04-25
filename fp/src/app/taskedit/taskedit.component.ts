import { Component, OnInit } from '@angular/core';
import { Task } from '../task';
import { TaskserviceService } from '../taskservice.service';
import { ActivatedRoute, Router } from '@angular/router';


interface City {
  priority: string;
}
@Component({
  selector: 'app-taskedit',
  templateUrl: './taskedit.component.html',
  styleUrls: ['./taskedit.component.css']
})
export class taskediteComponent implements OnInit {
  cities: City[] | undefined;

  selectedCity: City | undefined;

  editDetails:Task={
    taskId:'',
    title: '',
    description: '',
    dueDate: new Date(),
    priority: '',
    comments: '',
    status: '',
    attachment: '',
  };

  
  constructor(private taskService:TaskserviceService,private router:Router,private route:ActivatedRoute){}
  
  setDate(date: Date): Date {
    return new Date(date.getFullYear(), date.getMonth(), date.getDate());
  }
 
  handleSubmit() {
    const utcDate = this.setDate(this.editDetails.dueDate);
  }

 
  ngOnInit(): void {
     this.route.paramMap.subscribe({
      next:(params)=>
      {
        const taskId=params.get('taskId');
        console.log('Task ID:', taskId);
        if(taskId)
        {
          this.taskService.getTaskById(String(taskId))
          .subscribe({
            next:(response)=>{
               
              this.editDetails=response;
            }
          })
        }
        
      }
     });
     this.cities = [
      { priority: 'High' },
      { priority: 'Medium'},
      { priority: 'Low' },
  ];
    }
    
  
    updateTask()
    {
      this.taskService.updateTaskDetails(this.editDetails.taskId,this.editDetails)
      .subscribe({
        next:(response)=>
        {
          this.router.navigate(['tlist']);
          console.log(response);
        },
       
        error:(response)=>
        {
          console.log(response);
        }
      });
    }


  //   deleteTasks(taskId:string)
  // {
  //   this.taskService.deleteTask(taskId)
  //   .subscribe({
  //     next:(response)=>
  //     {
  //       this.router.navigate(['tlist']);
  //     },
  //     error:(response)=>
  //     {
  //       console.log(response);
  //     }
  //   });
  // }


  }