import { Component } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { Observable }     from 'rxjs/Observable';
import './rxjs-operators';
import {Customer} from 'Customer';

@Component({
  selector: 'my-app',
  template: `<h1>My First Angular 2 App</h1>
            <div>
                <button (click)='testHttp()'>Test HTTP</button>
            </div>`  
})
export class AppComponent {

    constructor(private http: Http) {

    }

    private data: any;

    testHttp() {
        console.log('testing http...');

        this.http.get('http://localhost:9000/api/values')
            .map(this.extractData)
            .catch(this.handleError)
            .subscribe((customers: Array<Customer>) => {
                for (let item of customers) {
                    console.log("Id: " + item.Id + " Name: " + item.Name);
                }
                //console.log(JSON.stringify(httpRes));
            });

        let name = "some value";
        let body = JSON.stringify({ value: 'some value' });
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });

        this.http.post('http://localhost:9000/api/values', body, options)
            .map(this.extractData)
            .catch(this.handleError)
            .subscribe((httpRes: Response) => {
                if (httpRes != null) {
                    console.log(JSON.stringify(httpRes));

                }
            });
    }

    private extractData(res: Response) {
        if (res.statusText != "No Content") {
            return res.json();
        }
        else {
            return null;
        }
    }

    private handleError(error: any) {
        // In a real world app, we might use a remote logging infrastructure
        // We'd also dig deeper into the error to get a better message
        let errMsg = (error.message) ? error.message :
            error.status ? `${error.status} - ${error.statusText}` : 'Server error';
        console.error(errMsg); // log to console instead
        return Observable.throw(errMsg);
    }

}
