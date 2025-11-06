import { Injectable } from '@angular/core';
import {
  HttpEvent,
  HttpInterceptor,
  HttpHandler,
  HttpRequest,
  HttpErrorResponse
} from '@angular/common/http';
import { Observable, catchError, throwError } from 'rxjs';

@Injectable()
export class ApiInterceptor implements HttpInterceptor {

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return next.handle(req).pipe(
      catchError((error: HttpErrorResponse) => {

        let userMessage = 'An unexpected error occurred. Please try again later.';

        if (error.error && error.error.message) {
          // This reads your backend ApiResponse<Message>
          userMessage = error.error.message;
        }

        switch (error.status) {
          case 400:
            userMessage = 'Bad Request: ' + (error.error?.message || 'Validation failed.');
            break;
          case 404:
            userMessage = 'Not Found: ' + (error.error?.message || 'The requested resource was not found.');
            break;
          case 500:
            userMessage = 'Server Error: Please contact support if this persists.';
            break;
        }

        // ✅ You can later replace this with a toast notification
        alert(userMessage);

        return throwError(() => error);
      })
    );
  }
}
