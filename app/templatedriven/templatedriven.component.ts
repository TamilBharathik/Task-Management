import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-templatedriven',
  templateUrl: './templatedriven.component.html',
  styleUrls: ['./templatedriven.component.css'] // Use styleUrls instead of styleUrl
})
export class TemplatedrivenComponent {
  form = {
    username: '',
    email: '',
    password: ''
  };

  onSubmit(): void {
    alert(JSON.stringify(this.form, null, 2));
  }

  onReset(form: NgForm): void {
    form.reset();
  }
}
