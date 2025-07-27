import React, { Component } from 'react';
import { BrowserRouter, Route, Routes, useParams } from 'react-router-dom';
import Collatz from './Collatz';
import Home from './Home';
import NotFound from './NotFound';

export default class Router extends Component {
    render() {

        function ConjeturaCollatzElement() {
            var { num } = useParams();
            return <Collatz numero={num}></Collatz>
        }

        return (
            <BrowserRouter>
                <Routes>
                    <Route path="/" element={<Home />} />
                    <Route path="/collatz/:num" element={<ConjeturaCollatzElement />} />
                    <Route path="*" element={<NotFound />} />
                </Routes>
            </BrowserRouter>
        )
    }
}
