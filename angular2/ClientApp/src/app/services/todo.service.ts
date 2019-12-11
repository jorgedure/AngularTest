import { Injectable } from '@angular/core';
import { Todo } from '../interfaces/todo';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { catchError } from 'rxjs/operators';
import { throwError as observableThrowError, Observable, ObservedValueOf } from 'rxjs';

const API_URL = ''; 
@Injectable({
  providedIn: 'root'
})
export class TodoService {
    todoTitle: string = '';
    allCompleted: boolean = true;
    todos: Todo[] = [];

    constructor(private http: HttpClient) {
    }

    getTodos(): Observable<Todo[]> {

        return this.http.get<Todo[]>(API_URL + '/api/Todo');
;
    }

    errorHandler(error: HttpErrorResponse) {
        return observableThrowError(error.message || 'Something went wrong!!!!');
    }

    addTodo(todoTitle: string): Observable<number> {
        if (todoTitle.trim().length === 0) {
            return;
        }
        return this.http.post<number>(API_URL + '/api/Todo/', { title: todoTitle }, { headers: this.getHeaders() });
    }
    deleteTodo(id: number): Observable<number> {
        return this.http.delete<number>(API_URL + '/api/Todo/' + id);
    }
    getHeaders(): HttpHeaders {
        let headers = new HttpHeaders();
        headers.append('Content-Type', 'json');


        return headers;
    }
    doneEdit(todo) {
        return this.http.post<number>(API_URL + '/api/Todo/Edit', todo , { headers: this.getHeaders() });
    }
    //checkAll(): Observable<Todo[]>{
    //    return this.http.post<Todo[]>(API_URL + '/api/Todo/CheckAll', { headers: this.getHeaders() });
    //}
}
