import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { AuthenticationService } from '../authentication.service';
import { User } from '../user.model';

@Component({
  selector: 'app-add-user',
  templateUrl: './add-user.component.html'
})
export class AddUserComponent implements OnInit {

  user: User;
  addUserFormGroup: FormGroup

  constructor(private formBuilder: FormBuilder, private authenticationService: AuthenticationService) {}

  ngOnInit(): void {
    this.addUserFormGroup = this.formBuilder.group({
      username: [''],
      email: [''],
      password: ['']
    })
  }

  addUser(){
    this.user = Object.assign({}, this.user, this.addUserFormGroup.value);
    
    this.authenticationService.addUser(this.user).subscribe();
    
  }
}
