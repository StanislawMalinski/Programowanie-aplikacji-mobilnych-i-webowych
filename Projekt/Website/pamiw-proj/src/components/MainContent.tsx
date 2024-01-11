import { Fragment, useEffect, useState } from "react";
import PostList from "./PostList";
import Paginator from "./Paginator";
import './MainContent.css'

import { GetPosts, GetMaxPosts, GetPostsForUser, GetMaxPostsForUser } from '../Client';

interface MainContentProps {
    navigateToProfile(): void;
    state: string

    setSelectedUser: (id: number) => void;
    selectedUser: number;
}

function MainContent(props: MainContentProps) {
    const [page, setPage] = useState(1);
    const [posts, setPosts] = useState([]);
    const [maxPages, setMaxPages] = useState(1);
    const id = 1;

    var content
    switch (props.state) {
        case "main-page":
            useEffect(() => {
                GetPosts(page)
                .then((res) => 
                    setPosts(res)
                ).catch((err) =>
                    console.error(err)
                );
                console.log(page);
            }, [page]);

            useEffect(() => {
                GetMaxPosts()
                .then((res) =>
                    setMaxPages(res)
                ).catch((err) =>
                    console.error(err)
                );
            }, [page]);

            content = <>
                <PostList posts={posts} 
                    navigateToUser={(id) => {
                        setPage(1);
                        props.setSelectedUser(id);
                        props.navigateToProfile();
                    }}/>
                </>;

            break;
        case "my-profile":
            useEffect(() => {
                GetPostsForUser(id, page)
                .then((res) => 
                    setPosts(res)
                ).catch((err) =>
                    console.error(err)
                );
            }, [page]);

            useEffect(() => {
                GetMaxPostsForUser(id)
                .then((res) => 
                    setMaxPages(res)
                ).catch((err) =>
                    console.error(err)
                );
            }, [page]);
            
            content = <>
                <PostList posts={posts} 
                    navigateToUser={(id) => {
                    setPage(1);
                    props.setSelectedUser(id);
                    props.navigateToProfile();
                    }}/>
                </>;

            break;
        case "new-post":
            content = <h1>New Post</h1>;
            break;
        case "profile":
            content = <h1>Profile</h1>;
            break;
        default:
            content = <h1>Something went wrong</h1>;
            break;
    }

    return (
        <>
            <div className="main-content-frame">
                <h1>Main Content</h1>
                <div className="paginator">
                    <Paginator  maxPages={maxPages} 
                                currentPage={page} 
                                setCurrentPage={setPage} />
                </div>  
                <div className="main-content">
                    {content}
                </div>
            </div>
        </>
    );
}

export default MainContent;