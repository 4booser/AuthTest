import { Component, inject, signal } from '@angular/core';
import { RouterLink } from '@angular/router';
import { LoginRequest } from '../../models/login-request';
import { AuthApiService } from '../../services/auth-api.service';

import { ReactiveFormsModule, FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-login',
  imports: [ReactiveFormsModule, RouterLink],
  templateUrl: './login.html',
  styleUrl: './login.scss'
})

export class Login {
  private readonly authApi = inject(AuthApiService);
  protected readonly isLoading = signal(false);

  protected readonly form = new FormGroup({
    email: new FormControl('', {
      nonNullable: true,
      validators: [Validators.required, Validators.email]
    }),
    password: new FormControl('', {
      nonNullable: true,
      validators: [Validators.required, Validators.minLength(6)]
    })
  });

  protected submit(): void {
    this.form.markAllAsTouched();

    if (this.form.invalid) {
      return;
    }

    const request: LoginRequest = this.form.getRawValue();

    this.isLoading.set(true);

    this.authApi.login(request).subscribe({
      next: response => {
        console.log('Login response:', response);
        this.isLoading.set(false);
      },
      error: error => {
        console.error('Login error:', error);
        this.isLoading.set(false);
      }
    });
  }
}