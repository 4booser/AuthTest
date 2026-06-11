import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { response } from 'express';
import { LoginResponse } from '../../app/features/auth/models/login-response';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private readonly http = inject(HttpClient);

  private readonly apiUrl = 'https://localhost:5092/api';

  register(): Observable<LoginResponse> {
    return this.http.get<LoginResponse>(`${this.apiUrl}/auth/register`);
  }
}